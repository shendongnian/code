    public static async Task<String> ToCompressedBase64(this StorageFile imageFile, Page localPage)
    {
        //Get the stream from the StorageFile
        IRandomAccessStream imageStream = await imageFile.OpenAsync(FileAccessMode.Read);
        System.Diagnostics.Debug.WriteLine("Original size ---> " + imageStream.ToFileSize());
        //Compresses the image if it exceedes the maximum file size
        imageStream.Seek(0);
        BitmapDecoder compressDecoder = await BitmapDecoder.CreateAsync(imageStream);
        PixelDataProvider compressionData = await compressDecoder.GetPixelDataAsync();
        byte[] compressionBytes = compressionData.DetachPixelData();
        //Set target compression quality
        BitmapPropertySet propertySet = new BitmapPropertySet();
        BitmapTypedValue qualityValue = new BitmapTypedValue(0.5, PropertyType.Single);
        propertySet.Add("ImageQuality", qualityValue);
        imageStream.Seek(0);
        imageStream = new InMemoryRandomAccessStream();
        BitmapEncoder compressionEncoder = await BitmapEncoder.CreateAsync(BitmapEncoder.JpegEncoderId, imageStream, propertySet);
        compressionEncoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Straight,
                                        compressDecoder.PixelWidth, compressDecoder.PixelHeight,
                                        compressDecoder.DpiX, compressDecoder.DpiY, compressionBytes);
        await compressionEncoder.FlushAsync();
        //Create a BitmapDecoder from the stream
        BitmapDecoder resizeDecoder = await BitmapDecoder.CreateAsync(imageStream);
    #if DEBUG
        System.Diagnostics.Debug.WriteLine("Old height and width ---> " + resizeDecoder.PixelHeight + " * " + resizeDecoder.PixelWidth + "\nCompressed size ---> " + imageStream.ToFileSize());
    #endif
        //Resize the image if needed
        TaskCompletionSource<bool> completionSource = new TaskCompletionSource<bool>();
        localPage.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
        {
            const int maxImageWidth = 48;
            if (resizeDecoder.PixelWidth > maxImageWidth)
            {
                //Resize the image if it exceedes the maximum width
                int newHeight = (int)(maxImageWidth * resizeDecoder.PixelHeight / resizeDecoder.PixelWidth);
                WriteableBitmap tempBitmap = new WriteableBitmap((int)resizeDecoder.PixelWidth, (int)resizeDecoder.PixelHeight);
                imageStream.Seek(0);
                await tempBitmap.SetSourceAsync(imageStream);
                WriteableBitmap resizedImage = tempBitmap.Resize(maxImageWidth, newHeight, WriteableBitmapExtensions.Interpolation.Bilinear);
                //Assign to imageStream the resized WriteableBitmap
                InMemoryRandomAccessStream resizedStream = new InMemoryRandomAccessStream();
                await resizedImage.ToStream(resizedStream, BitmapEncoder.JpegEncoderId);
                imageStream = resizedStream;
            }
            completionSource.SetResult(true);
        }).Forget();
        await completionSource.Task;           
        //Converts the final image into a Base64 String
        imageStream.Seek(0);
        BitmapDecoder decoder = await BitmapDecoder.CreateAsync(imageStream);
        PixelDataProvider pixels = await decoder.GetPixelDataAsync();
    #if DEBUG
        System.Diagnostics.Debug.WriteLine("New height and width ---> " + decoder.PixelHeight + " * " + decoder.PixelWidth + "\nSize after resize ---> " + imageStream.ToFileSize());
    #endif
        byte[] bytes = pixels.DetachPixelData();
        //Encode image
        InMemoryRandomAccessStream encoded = new InMemoryRandomAccessStream();
        BitmapEncoder encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.JpegEncoderId, encoded);
        encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Straight, decoder.PixelWidth, decoder.PixelHeight, decoder.DpiX, decoder.DpiY, bytes);
        await encoder.FlushAsync();
        encoded.Seek(0);
        //Read bytes
        byte[] outBytes = new byte[encoded.Size];
        await encoded.AsStream().ReadAsync(outBytes, 0, outBytes.Length);
        //Create Base64
        return Convert.ToBase64String(outBytes);
    }
