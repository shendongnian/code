    async Task Base64ToImage()
    {
        using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
        using (IsolatedStorageFileStream stream = isf.OpenFile("newReConvertedFile.png", FileMode.Create))
        using (IsolatedStorageFileStream isfs = isf.OpenFile("image.p64", FileMode.Open, FileAccess.ReadWrite))
        {
             await isfs.CopyToAsync(stream);
        }      
    
        await ReLoadFile();
    }
    async Task ReLoadFile()
    {
    
    
        using (IsolatedStorageFile newFileLoc = IsolatedStorageFile.GetUserStoreForApplication())
        {
            using (IsolatedStorageFileStream newFileStream = newFileLoc.OpenFile("newReConvertedFile.png", FileMode.Open, FileAccess.ReadWrite))
            {
                var ms = new MemoryStream(newFileStream.Length);
                var image = new BitmapImage();
                await newFileStream.CopyToAsync(ms);
                ms.Position = 0;    
                image.SetSource(ms); 
                theImage.Source = image; 
            }
         }
     }
    async Task Base64ToImage()
    {
        using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
        using (IsolatedStorageFileStream isfs = isf.OpenFile("image.p64", FileMode.Open, FileAccess.ReadWrite))
        {
             var image = new BitmapImage(isfs.Length);
             await isfs.CopyToAsync(ms);
    
             ms.Position = 0;  
             image.SetSource(ms); 
             theImage.Source = image; 
        }      
    }
