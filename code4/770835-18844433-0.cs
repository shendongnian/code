    using (StorageItemThumbnail thumbnail = await MediaFile.GetThumbnailAsync(ThumbnailMode.MusicView, 300))
    {
        if (thumbnail != null && thumbnail.Type == ThumbnailType.Image)
        {
            var bitmapImage = new BitmapImage();
            bitmapImage.SetSource(thumbnail);
            ImageControl.Source = bitmapImage;
        }
    }
