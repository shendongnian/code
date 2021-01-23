    private async Task<StorageFile> WriteableBitmapToStorageFile(WriteableBitmap writeableBitmap)
    {
        var picker = new FileSavePicker();
        picker.FileTypeChoices.Add("JPEG Image", new string[] { ".jpg" });
        StorageFile file = await picker.PickSaveFileAsync();
        if (file != null && writeableBitmap != null)
        {
            using (IRandomAccessStream stream = await file.OpenAsync(FileAccessMode.ReadWrite))
            {
                BitmapEncoder encoder = await BitmapEncoder.CreateAsync(
                    BitmapEncoder.JpegEncoderId, stream);
                Stream pixelStream = writeableBitmap.PixelBuffer.AsStream();
                byte[] pixels = new byte[pixelStream.Length];
                await pixelStream.ReadAsync(pixels, 0, pixels.Length);
    
                encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Ignore,
                    (uint)writeableBitmap.PixelWidth, (uint)writeableBitmap.PixelHeight, 96.0, 96.0, pixels);
                await encoder.FlushAsync();
            }
            return file;
        }
        else
        {
            return null;
        }
    }
