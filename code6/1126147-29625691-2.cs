    public ImageSource Image
    {
        get
        {
            using (var fs = new FileStream(FileName, FileMode.Open, FileAccess.Read))
            {
                return BitmapFrame.Create(
                    fs, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
            }
        }
    }
