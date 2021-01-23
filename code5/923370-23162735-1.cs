    public static async Task SaveToFile(
        this WriteableBitmap writeableBitmap,
        StorageFile outputFile,
        Guid encoderId)
    {
        Stream stream = writeableBitmap.PixelBuffer.AsStream();
        byte[] pixels = new byte[(uint)stream.Length];
        await stream.ReadAsync(pixels, 0, pixels.Length);
        using (var writeStream = await outputFile.OpenAsync(FileAccessMode.ReadWrite))
        {
            var encoder = await BitmapEncoder.CreateAsync(encoderId, writeStream);
            encoder.SetPixelData(
                BitmapPixelFormat.Bgra8,
                BitmapAlphaMode.Premultiplied,
                (uint)writeableBitmap.PixelWidth,
                (uint)writeableBitmap.PixelHeight,
                96,
                96,
                pixels);
            await encoder.FlushAsync();
            using (var outputStream = writeStream.GetOutputStreamAt(0))
            {
                await outputStream.FlushAsync();
            }
        }
    }
