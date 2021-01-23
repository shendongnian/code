    public static async Task SaveImageAsync(string imageFileName, BitmapImage image)
    {
        // Get Students LocalFolder
        IStorageFolder folder = await ApplicationData.Current.LocalFolder
            .CreateFolderAsync("Images", CreationCollisionOption.OpenIfExists);
            
            
            IStorageFile file = await folder.CreateFileAsync(
                imageFileName, CreationCollisionOption.ReplaceExisting);
            using (Stream stream = await file.OpenStreamForWriteAsync())
            {                
                var wrBitmap = new WriteableBitmap(image);
                wrBitmap.SaveJpeg(stream, image.PixelWidth, image.PixelHeight, 100, 100);
            }
        }
