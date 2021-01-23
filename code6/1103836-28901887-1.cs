    // we are using these test data:
    int Dpi = 150;
    float targetHeight = 1.00f;
    FontFamily ff = new FontFamily("Consolas");
    int fs = (int) FontStyle.Regular;
    string targetString = "X";
    // this would be the height without the white space
    int targetPixels = (int) targetHeight * Dpi;
    // we write to a Btimpap. I make it large enough..
    // Instead you can write to a printer or a Control surface..
    using (Bitmap bmp = new Bitmap(targetPixels * 2, targetPixels * 2))
    {
        // either set the resolution here
        // or get and use it above from the Graphics!
        bmp.SetResolution(Dpi, Dpi);
        using (Graphics G = Graphics.FromImage(bmp))
        {
            // good quality, please!
            G.SmoothingMode = SmoothingMode.AntiAlias;
            G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            PointF p0 = new PointF(0, 0);
            GraphicsPath gp = new GraphicsPath();
            // first try:
            gp.AddString(targetString, ff, fs, targetPixels, p0,
                         StringFormat.GenericDefault);
            // this is the 1st result
            RectangleF gbBounds = gp.GetBounds();
            // now we correct the height:
            float tSize = targetPixels * targetPixels / gbBounds.Height;
            // and retry
            gp.Reset();
            gp.AddString(targetString, ff, fs, tSize, p0, StringFormat.GenericDefault);
            // this should be good
            G.Clear(Color.White);
            G.FillPath(Brushes.Black, gp);
        }
        //now we save the image 
        bmp.Save("D:\\testString.png", ImageFormat.Png);
    }
