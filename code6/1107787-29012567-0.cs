    BitmapImage image = new BitmapImage();
    try
    {
        using (FileStream stream = File.OpenRead(filePath))
        {
            image.BeginInit();
            image.StreamSource = stream;
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.EndInit();
        }
    }
    catch { return DependencyProperty.UnsetValue; }
