    public async Task<BitmapImage> ConvertToBitmapImage(byte[] image)
    {
        InMemoryRandomAccessStream ras = new InMemoryRandomAccessStream();
        var bitmapImage = new BitmapImage();
        var memoryStream = new MemoryStream(image);
        await memoryStream.CopyToAsync(ras.AsStreamForWrite());
        await bitmapImage.SetSourceAsync(ras);
        return bitmapImage;
    }
    
    Image img = new Image();
    img.Source = await ConvertToBitmapImage(picturebytearray);
    rootgrid.Children.Add(img);
