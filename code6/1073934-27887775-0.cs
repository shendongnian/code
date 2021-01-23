    public static async Task<WriteableBitmap> GetWritableBitmapFromStream(Stream stream)
    {
        var decoder = await BitmapDecoder.CreateAsync(stream.AsRandomAccessStream());
        var pixelData = await decoder.GetPixelDataAsync(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Ignore, new BitmapTransform(), ExifOrientationMode.IgnoreExifOrientation, ColorManagementMode.DoNotColorManage);
        var pixels = pixelData.DetachPixelData();
        var bmp = new WriteableBitmap((int)decoder.PixelWidth, (int)decoder.PixelHeight);
        using (var bmpStream = bmp.PixelBuffer.AsStream())
        {
            bmpStream.Seek(0, SeekOrigin.Begin);
            await bmpStream.WriteAsync(pixels, 0, (int)bmpStream.Length);
        }
        return bmp;
    }
    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        var files = await KnownFolders.CameraRoll.GetFilesAsync();
        foreach (var file in files)
        {
            // need "using System.IO" for this extension method
            using (var fileStream = await file.OpenStreamForReadAsync())
            {
                WriteableBitmap writeableBmp = await GetWritableBitmapFromStream(fileStream);
                // do something with writableBmp
            }
        }
    }
