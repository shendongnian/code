    // we will store actual bounds in here
    int left, right, top, bottom;
    using (Bitmap b = ...) // open image here
    {
        var pixelsX = Enumerable.Range(0, b.Width);
        var pixelsY = Enumerable.Range(0, b.Height);
        left   = pixelsX.FirstOrDefault(
                    x => pixelsY.Any(y => b.GetPixel(x, y).A != 0));
        right  = pixelsX.Reverse().FirstOrDefault(
                    x => pixelsY.Any(y => b.GetPixel(x, y).A != 0));
        top    = pixelsY.FirstOrDefault(
                    y => pixelsX.Any(x => b.GetPixel(x, y).A != 0));
        bottom = pixelsY.Reverse().FirstOrDefault(
                    y => pixelsX.Any(x => b.GetPixel(x, y).A != 0));
    }
    
