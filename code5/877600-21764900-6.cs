    async Task Base64ToImage()
    {
        using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
        using (IsolatedStorageFileStream isfs = isf.OpenFile("image.p64", FileMode.Open, FileAccess.ReadWrite))
        {
             var ms = new MemoryStream();
             var image = new BitmapImage();
             await isfs.CopyToAsync(ms);
    
             ms.Position = 0;
             image.SetSource(ms); 
             theImage.Source = image; 
        }      
    }
