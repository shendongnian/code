    int quality = 90;
    
    using (var ms = new System.IO.MemoryStream()) {
        bmp.SaveJpeg(ms, bmp.PixelWidth, bmp.PixelHeight, 0, quality);
        item.Tile = ms.ToArray();
    }
