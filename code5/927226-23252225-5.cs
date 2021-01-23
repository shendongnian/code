    private async void loadPressed(object sender, Windows.UI.Xaml.RoutedEventArgs e)
    {
        // TODO: Add event handler implementation here.
        DataStoreHelper dataHelper = DataStoreHelper.Instance;
        Signature sig = await dataHelper.getSignature(1);
        Debug.WriteLine("----" + sig.name);
        Debug.WriteLine("----" + sig.imgData);
        Debug.WriteLine("----" + sig.imgData.Length);
        byte[] bytes = Convert.FromBase64String(sig.imgData);
        
        SigImage.Source = await ByteArrayToBitmapImage(bytes);
    }
    private async Task<BitmapImage> ByteArrayToBitmapImage(byte[] byteArray)
    {
        var bitmapImage = new BitmapImage();
        var stream = new InMemoryRandomAccessStream();
        await stream.WriteAsync(byteArray.AsBuffer());
        stream.Seek(0);
        bitmapImage.SetSource(stream);
        return bitmapImage;
    }
