    using(var targetFile=System.IO.IsolatedStorage.IsolatedStorageFile.GetUserStoreForApplication()
    .OpenFile("fileName", FileMode.Open))
    {
        PosterLocal = PictureDecoder.DecodeJpeg(targetFile, 100, 100);
    }
