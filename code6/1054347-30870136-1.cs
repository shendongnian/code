    public Task<byte[]> ReadAsPngImageAsync()
    {
        return ReadImageFromWritableBitmapAsync(_writeableBitmap, Windows.Graphics.Imaging.BitmapEncoder.PngEncoderId);
    }
    internal static async Task<byte[]> ReadImageFromWritableBitmapAsync(Windows.UI.Xaml.Media.Imaging.WriteableBitmap writeableBitmap, Guid encoderId)
    {
        var rawPixels = await ConvertBitmapToByteArrayAsync(writeableBitmap);
        var encodedPixels = await EncodePixels(rawPixels, encoderId, (uint)writeableBitmap.PixelWidth, (uint)writeableBitmap.PixelHeight);
        return encodedPixels;
    }
    private static async Task<byte[]> ConvertBitmapToByteArrayAsync(Windows.UI.Xaml.Media.Imaging.WriteableBitmap bitmap)
    {
        using (var stream = bitmap.PixelBuffer.AsStream())
        {
            var pixels = new byte[(uint)stream.Length];
            await stream.ReadAsync(pixels, 0, pixels.Length);
            return pixels;
        }
    }
    private static async Task<byte[]> EncodePixels(byte[] signaturePixels, Guid encoderId, uint pixelWidth, uint pixelHeight)
    {
        using (var randomAccessStream = new Windows.Storage.Streams.InMemoryRandomAccessStream())
        {
            var encoder = await Windows.Graphics.Imaging.BitmapEncoder.CreateAsync(encoderId, randomAccessStream);
            encoder.SetPixelData(Windows.Graphics.Imaging.BitmapPixelFormat.Bgra8, Windows.Graphics.Imaging.BitmapAlphaMode.Premultiplied,
                pixelWidth, pixelHeight,
                96, 96, signaturePixels);
            await encoder.FlushAsync();
            using (var stream = randomAccessStream.GetInputStreamAt(0))
            {
                var pixels = new byte[(uint)randomAccessStream.Size];
                stream.AsStreamForRead().Read(pixels, 0, pixels.Length);
                return pixels;
            }
        }
    }
