﻿using Ookii.Dialogs.Wpf;
using System.Collections.Generic;
using System.Windows;

namespace ArcFaceWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> paths = new List<string>();

        private string defaultFolderPath = System.IO.Path.GetFullPath("../../../../images");

        public MainWindow()
        {
            InitializeComponent();
            MainViewModel = new MainViewModel();
            DataContext = MainViewModel;
        }

        public MainViewModel MainViewModel { get; set; }

        private void OnOpenButtonClicked(object sender, RoutedEventArgs e)
        {
            var dlg = new VistaFolderBrowserDialog();

            if (dlg.ShowDialog() == true)
            {
                MainViewModel.FolderPath = dlg.SelectedPath;
            }
        }

        private async void StartButtonClick(object sender, RoutedEventArgs e)
        {
            if (MainViewModel.FolderPath == null)
            {
                MessageBox.Show("Выберите папку.", "Папка не выбрана.");
                return;
            }

            if(MainViewModel.ImagesPaths == null || MainViewModel.ImagesPaths.Length == 0)
            {
                MessageBox.Show("В папке нет картинок.", "В папке нет картинок.");
                return;
            }

            await MainViewModel.Start();
        }

        private void CancellButtonClick(object sender, RoutedEventArgs e)
        {
            MainViewModel.Cancel();
        }

        private void ClearButtonClick(object sender, RoutedEventArgs e)
        {
            MainViewModel.Clear();
            DataTable.Clear();
        }
    }
}
