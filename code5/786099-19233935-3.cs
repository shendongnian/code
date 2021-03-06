    var picker = new FileOpenPicker();
    picker.FileTypeFilter.Add(".jpg");
    StorageFile file = await picker.PickSingleFileAsync();
    if (file != null)
    {
        using (IRandomAccessStream ras = await file.Openasync(FileAccessMode.Read))
        {
            BitmapDecoder decoder = await BitmapDecoder.CreateAsync(ras);
            PixelDataProvider provider = await decoder.GetPixelDataAsync(decoder.BitmapPixelFormat, decoder.BitmapAlphaMode, new BitmapTransform(), ExifOrientationMode.RespectExifOrientation, ColorManagementMode.ColorManageToSRgb);
            byte[] pixels = provider.DetachPixelData();
            for (int i = 0; i < pixels.Length; i += 4)
            {
                pixels[i] = (byte)(pixels[i] + 72);
            }
            WriteableBitmap bitmap = new WriteableBitmap((int)decoder.OrientedPixelWidth, (int)decoder.OrientedPixelHeight);
            using (Stream stream = bitmap.PixelBuffer.AsStream())
            {
                await stream.WriteAsync(pixels, 0, pixels.Length);
            }
            image.Source = bitmap;
        }
    }
