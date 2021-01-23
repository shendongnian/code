    var bitmapImage = new BitmapImage();
    //Get Album cover
    using (StorageItemThumbnail thumbnail = await file.GetThumbnailAsync(ThumbnailMode.MusicView, 300))
    {
         if (thumbnail != null && thumbnail.Type == ThumbnailType.Image)
         {
             bitmapImage.SetSource(thumbnail);
         }
         else
         {
             //Error Message here
         }
    }
