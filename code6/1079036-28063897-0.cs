    public Image GetImage(StorageFile storageFile)
    {
        var bitmapImage = new BitmapImage();
        GetImageAsync(bitmapImage, storageFile);
    
        // Create an image or return a bitmap that's started loading
        var image = new Image();
        image.Source = bitmapImage;
    
        return image ;
    }
    
    private async Task GetImageAsync(BitmapImage bitmapImage, StorageFile storageFile)
    {
        using (var stream = (FileRandomAccessStream)await storageFile.OpenAsync(FileAccessMode.Read))
        {
            await bitmapImage.SetSource(stream);
        }
    }
