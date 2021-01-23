    public static async Task PadPngImage(StorageFile inputFile, StorageFile outputFile, uint width, uint height, uint boundingBoxWidth, uint boundingBoxHeight)
    {
        // Resize the input image
        StorageFile temporaryFile = await ApplicationData.Current.TemporaryFolder.CreateFileAsync("PadImageTemporaryFile.png", CreationCollisionOption.ReplaceExisting);
        await ResizeImage(inputFile, temporaryFile, width, height);            
        // Create a stream linked to resized image
        using (IRandomAccessStream temporaryFileStream = await temporaryFile.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite))
        {
            WriteableBitmap bitmap = await BitmapFactory.New(1, 1).FromStream(temporaryFileStream);
            // Create an empty image with specified bounding dimentions
            WriteableBitmap bitmapDummy = BitmapFactory.New((int)boundingBoxWidth, (int)boundingBoxHeight);
            using (bitmapDummy.GetBitmapContext())
            {
                using (bitmap.GetBitmapContext())
                {
                    // Calculate position of the image
                    Rect center = new Rect((boundingBoxWidth - width) / 2, (boundingBoxHeight - height) / 2, width, height);
                    bitmapDummy.Blit(center, bitmap, new Rect(0.0, 0.0, width, height), WriteableBitmapExtensions.BlendMode.None);                        
                }
            }
            using(IRandomAccessStream stream = await outputFile.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite))
            {
                await bitmapDummy.ToStream(stream, BitmapEncoder.PngEncoderId);
            }                
        }
    }
    public static async Task ResizeImage(StorageFile inputFile, StorageFile outputFile, uint newWidth, uint newHeight)
    {
        // Input Stream & Decoder
        using (IRandomAccessStream fileStream = await inputFile.OpenAsync(Windows.Storage.FileAccessMode.Read))
        {
            BitmapDecoder decoder = await BitmapDecoder.CreateAsync(fileStream);
                
            // Output Stream & Encoder                
            using (IRandomAccessStream stream = await outputFile.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite))
            {
                BitmapEncoder encoder = await BitmapEncoder.CreateForTranscodingAsync(stream, decoder);
                // Scale the bitmap image
                encoder.BitmapTransform.ScaledWidth = newWidth;
                encoder.BitmapTransform.ScaledHeight = newHeight;
                encoder.BitmapTransform.InterpolationMode = BitmapInterpolationMode.Fant;
                await encoder.FlushAsync();
            }
        }
    }
