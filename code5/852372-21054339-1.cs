    if (bitmapImage != null) {
        // create WriteableBitmap object from captured BitmapImage
        WriteableBitmap writeableBitmap = new WriteableBitmap(bitmapImage);
    
        using (MemoryStream ms = new MemoryStream())
        {
            writeableBitmap.SaveJpeg(ms, writeableBitmap.PixelWidth, writeableBitmap.PixelHeight, 0, 100);
    
            ms.Position = 0;
            imageBuffer = new byte[ms.Length];
            ms.Read(imageBuffer, 0, imageBuffer.Length);
            ms.Dispose();
        }                
    }
