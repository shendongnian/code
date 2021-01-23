    private void LoadPic()
    {
        string fn = @"C:\Folder\image" + (frame % 2).ToString() + ".png";
        Bitmap bmp = new Bitmap(302, 170);
        bmp.Save(fn);
        bmp.Dispose();
        var img = new System.Windows.Media.Imaging.BitmapImage();
        img.BeginInit();
        img.CacheOption = System.Windows.Media.Imaging.BitmapCacheOption.OnLoad;
        img.UriSource = new Uri(fn);
        img.EndInit();
        Picbox.Source = img;
    }
