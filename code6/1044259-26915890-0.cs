    WriteableBitmap writeableSource = new WriteableBitmap(100, 100, 96, 96, PixelFormats.Bgra32, null);
    
    // Calculate the number of bytes per pixel. 
    int _bytesPerPixel = (writeableSource .Format.BitsPerPixel + 7) / 8;
    // Stride is bytes per pixel times the number of pixels.
    // Stride is the byte width of a single rectangle row.
    int _stride = writeableSource .PixelWidth * _bytesPerPixel;
    
    private void SomeUpdateFunction()
    {
         // Define the rectangle of the writeable image we will modify. 
         // The size is that of the writeable bitmap.
         Int32Rect _rect = new Int32Rect(0, 0, _wb.PixelWidth, _wb.PixelHeight);
    
        //Update writeable bitmap with the colorArray to the image.
        _wb.WritePixels(_rect, pixelBuffer, _stride, 0);
        TrackingImage.Source = writeableSource;
    }
