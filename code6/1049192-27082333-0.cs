    private static async Task<BitmapImage> GetImageFromStorageAsync(string fileName)
    {
        var bytes = await Task.Factory
                     .StartNew((f)=>Utils.GetImageFromStorage((string)f), fileName)
                     .ConfigureAwait(false);
        MemoryStream memStream = new MemoryStream(bytes);
        BitmapImage image = new BitmapImage();
        image.SetSource(memStream);
        return image;
    }
    
    private async Task SetImage()
    {
        var image = await GetImageFromStorageAsync(fileName);
        userImage.Source = image;
    }
