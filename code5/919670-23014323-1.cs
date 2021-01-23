    public static BitmapImage LoadImage(string imageFileName)
    {
        BitmapImage bitmapImage = null;
        using (var isoFile = IsolatedStorageFile.GetUserStoreForApplication())
        {
             using (var isoStream = isoFile.OpenFile(
                 imageFileName, FileMode.Open, FileAccess.Read))
             {
                  bitmapImage = new BitmapImage();
                  bitmapImage.SetSource(isoStream);
             }
        }
        return bitmapImage;
    }
