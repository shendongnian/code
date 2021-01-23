    Bitmap b = new Bitmap(width * 2, height * 2);
    using (Graphics g1 = Graphics.FromImage((Image)b))
    {
    	g1.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
    	g1.DrawImage(newBitmap, 0, 0, width * 2, height * 2);
    }
