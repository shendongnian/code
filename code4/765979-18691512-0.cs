    public static void SaveImage(Stream image, string name)
    {
        var bitmap = new BitmapImage();
        bitmap.SetSource(attachmentStream);
        var wb = new WriteableBitmap(bitmap);
        var temp = new MemoryStream();
        wb.SaveJpeg(temp, wb.PixelWidth, wb.PixelHeight, 0, 50);
        using (var myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
        {
            if (!myIsolatedStorage.DirectoryExists("MyImages"))
            {
                myIsolatedStorage.CreateDirectory("MyImages");
            }
            var filePath = Path.Combine("MyImages", name + ".jpg");
    
            using (IsolatedStorageFileStream fileStream = new IsolatedStorageFileStream(filePath, FileMode.Create, myIsolatedStorage))
            {
                fileStream.Write(((MemoryStream)temp).ToArray(), 0, ((MemoryStream)temp).ToArray().Length);
                fileStream.Close();
            }
        }
    }
