    var userImage = new BitmapImage();
    
    using (var stream = new MemoryStream(...))
    {
        userImage.BeginInit();
        userImage.CacheOption = BitmapCacheOption.OnLoad;
        userImage.StreamSource = stream;
        userImage.EndInit();
    }
    UserImage = userImage;
