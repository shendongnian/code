    public Windows.UI.Xaml.Media.Imaging.BitmapImage byteArrayToImage(byte[] byteArrayIn)
    {
        using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
        {
            await stream.WriteAsync(byteArrayIn.AsBuffer(0, byteArrayIn.Length));
            stream.Seek(0);
            BitmapImage image = new BitmapImage();
            await image.SetSourceAsync(stream);
 
            return image;
        }
    }
