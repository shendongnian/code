    wrt = new WriteableBitmap(imag, null);
    try
    {
        System.Windows.Media.Color c = new System.Windows.Media.Color();
        c.A = 0;
        c.B = 0; c.R = 0; c.G = 0;
        currentPoint = e.GetPosition(this.imag);
        int width = wrt.PixelWidth;
        for (int degrees = 0; degrees <= 360; degrees++)
        {
            for (int distance = 0; distance <= erasersize; distance++)
            {
                //double angle = Math.PI * degrees / 180.0;
                double x = currentPoint.X + (distance * Math.Cos(degrees));
                double y = currentPoint.Y + (distance * Math.Sin(degrees));
                wrt.Pixels[(int)(y - offset) * width + (int)x] = ColorToInt(c);
            }
        }
    }
