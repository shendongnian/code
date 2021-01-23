    private async void photoChooserTask_Completed(object sender, PhotoResult e)
    {
        if (e.TaskResult == TaskResult.OK)
        {
            // Load the image source into a writeable bitmap
            BitmapImage bi = new BitmapImage();
            bi.SetSource(e.ChosenPhoto);
            WriteableBitmap wb = new WriteableBitmap(bi);
            // Buffer the photo content in memory (90% quality; adjust parameter as needed)
            byte[] buffer = null;
            using (var ms = new System.IO.MemoryStream())
            {
                int quality = 90;
                e.ChosenPhoto.Seek(0, SeekOrigin.Begin);
                
                // TODO: Crop or rotate here if needed
                // Resize the photo by changing parameters to SaveJpeg() below if desired
                wb.SaveJpeg(ms, wb.PixelWidth, wb.PixelHeight, 0, quality);
                buffer = ms.ToArray();
            }
            // Save the image to isolated storage with new Win 8 APIs
            var isoFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            var nextImageName = Guid.NewGuid() + ".jpg";
            var newImageFile = await isoFolder.CreateFileAsync(nextImageName, Windows.Storage.CreationCollisionOption.FailIfExists);
            using (var wfs = await newImageFile.OpenStreamForWriteAsync())
            {
                wfs.Write(buffer, 0, buffer.Length);
            }
            // Use the path property of the StorageFile to set the lock screen URI
            Windows.Phone.System.UserProfile.LockScreen.SetImageUri(new Uri(newImageFile.Path, UriKind.Absolute));
        }
    }
