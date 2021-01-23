    // Read the retrieved image's bytes and write them into an IRandomAccessStream
    IBuffer buffer = await response.Content.ReadAsBufferAsync();
    var randomAccessStream = new InMemoryRandomAccessStream();
    await randomAccessStream.WriteAsync(buffer);
    
    // Decode the downloaded image as Bgra8 with premultiplied alpha
    // GetPixelDataAsync lets us pass in the desired format and it'll do the magic to translate as it decodes
    BitmapDecoder decoder = await BitmapDecoder.CreateAsync(randomAccessStream);
    var pixelData = await decoder.GetPixelDataAsync(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Premultiplied, new BitmapTransform(), ExifOrientationMode.IgnoreExifOrientation, ColorManagementMode.DoNotColorManage);
    
    // Get the decoded bytes
    byte[] imageData = pixelData.DetachPixelData();
    
    // And stick them in a WriteableBitmap
    WriteableBitmap image = new WriteableBitmap((int)decoder.PixelWidth,(int) decoder.PixelHeight);
    Stream pixelStream = image.PixelBuffer.AsStream();
    
    pixelStream.Seek(0, SeekOrigin.Begin);
    pixelStream.Write(imageData, 0, imageData.Length);
    
    // And stick it in an Image so we can see it.
    RadarImage.Source = image;
