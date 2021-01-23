    var bitmap = new WriteableBitmap(width, height, 96, 96,           System.Windows.Media.PixelFormats.BlackWhite, null);
    bitmap.WritePixels(new System.Windows.Int32Rect(0, 0, width, height), newarray, stride, 0);     
    MemoryStream stream3 = new MemoryStream();
    var encoder = new TiffBitmapEncoder ();
    encoder.Frames.Add(BitmapFrame.Create(bitmap));
    encoder.Save(stream3);
