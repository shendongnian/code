    public ImageSource Image
    {
        get
        {
            ...
            var bi = new BitmapImage();
            using (var fs = new FileStream(FileName, FileMode.Open, FileAccess.Read))
            {
                bi.BeginInit();
                bi.CacheOption = BitmapCacheOption.OnLoad;
                bi.StreamSource = fs;
                bi.EndInit();
            }
            return bi;
        }
