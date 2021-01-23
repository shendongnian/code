    using (Bitmap bmp = new Bitmap(x, y, 
             System.Drawing.Imaging.PixelFormat.Format32bppArgb))
    {
        using (Graphics gr = Graphics.FromImage(bmp))
        {
                        
            gr.SmoothingMode = SmoothingMode.HighQuality;
            gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
            gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
            gr.DrawImage(src, new Rectangle(0, 0, x, y));
        }
    }
