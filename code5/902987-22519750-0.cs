    private static async Task<BitmapImage> LoadImageAsync(StorageFile pictureFile)
    {
        using (var stream = await pictureFile.GetThumbnailAsync(
            ThumbnailMode.SingleItem,
            320,
            ThumbnailOptions.ResizeThumbnail))
        {
            var bitmap = new BitmapImage();
            await bitmap.SetSourceAsync(stream);
            return bitmap;
        }
    }
