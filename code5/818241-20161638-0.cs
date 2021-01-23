    string imageFolder = @"\Shared\ShellContent"; 
    string shareJPEG = "FILENAME.jpg";
    private void SaveImage(Stream result)
    {
        using (IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForApplication())
        {
            if(!myIsolatedStorage.DirectoryExists(imageFolder))
            {
                myIsolatedStorage.CreateDirectory(imageFolder);
            }
            if (myIsolatedStorage.FileExists(shareJPEG))
            {
                myIsolatedStorage.DeleteFile(shareJPEG);
            }
            string filePath = System.IO.Path.Combine(imageFolder, shareJPEG);
            IsolatedStorageFileStream fileStream = myIsolatedStorage.CreateFile(filePath);
            BitmapImage bitmap = new BitmapImage();
            bitmap.SetSource(result);
            WriteableBitmap wb = new WriteableBitmap(bitmap);
            // Encode WriteableBitmap object to a JPEG stream. 
            int width = wb.PixelWidth;
            int height = wb.PixelHeight;
            if (wb.PixelWidth > 336)
            {
                width = 336;
            }
            if (wb.PixelHeight > 336)
            {
                height = 336;
            }
            Extensions.SaveJpeg(wb, fileStream, width, height, 0, 100);
            fileStream.Close();
            
        }
    } 
    private void CreateTile()
    {
        var tileData = new FlipTileData()
        {
             ....
             string filePath = System.IO.Path.Combine(imageFolder, shareJPEG);                
             BackgroundImage = new Uri(@"isostore" + filePath, UriKind.Absolute);
             ....
        } 
    }
