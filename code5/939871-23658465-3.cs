    private void Button_Click(object sender, RoutedEventArgs e) // To load another image
    {
        var dialog = new Microsoft.Win32.OpenFileDialog();
        dialog.Filter =
            "Image Files (*.jpg;*.png; *.jpeg; *.gif; *.bmp)|*.jpg;*.png; *.jpeg; *.gif; *.bmp";
    
        if ((bool)dialog.ShowDialog())
        {
            BitmapImage src = new BitmapImage();
            src.BeginInit();
            src.UriSource = new Uri(dialog.FileName, UriKind.Relative);
            src.DecodePixelHeight = 120;
            src.DecodePixelWidth = 120;
            src.CacheOption = BitmapCacheOption.OnLoad;
            src.EndInit();
    
            var image = new Image { Source = src };
    
            Point p = SpecialPhoto.TranslatePoint(new Point(0, 0), canvas);
            Canvas.SetLeft(image, p.X);
            Canvas.SetTop(image, p.Y);
            canvas.Children.Add(image);
        }
    }
