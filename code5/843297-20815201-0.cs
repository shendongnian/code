    private void b3_Click(object sender, RoutedEventArgs e)
    {
        System.Windows.Forms.OpenFileDialog openDialogIcon = new System.Windows.Forms.OpenFileDialog();
        if (openDialogIcon.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
            BitmapImage src = new BitmapImage();
            src.BeginInit();
            src.UriSource = new Uri(openDialogIcon.FileName, UriKind.Absolute);
            src.CacheOption = BitmapCacheOption.OnLoad;
            src.EndInit();
            pictureBox1.Source = src;
        }
    }
