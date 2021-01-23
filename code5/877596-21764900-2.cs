    async Task Base64ToImage()
    {
        using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
        using (IsolatedStorageFileStream isfs = isf.OpenFile("image.p64", FileMode.Open, FileAccess.ReadWrite))
        {
             var image = new BitmapImage();
             await isfs.CopyToAsync(ms);
    
             image.SetSource(ms); 
             theImage.Source = image; 
        }      
    }
