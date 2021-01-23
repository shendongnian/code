    async Task Base64ToImage()
    {
        using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
        using (IsolatedStorageFileStream stream = isf.OpenFile("newReConvertedFile.png", FileMode.Create))
        using (IsolatedStorageFileStream isfs = isf.OpenFile("image.p64", FileMode.Open, FileAccess.ReadWrite))
        {
             await isfs.CopyToAsync(stream);
        }      
    
        reLoadFile();
    }
