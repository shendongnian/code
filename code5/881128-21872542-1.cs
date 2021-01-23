    int hw = 1;
    Bitmap Bmp = new Bitmap(hw, hw, 
                            System.Drawing.Imaging.PixelFormat.Format24bppRgb);
    using (Graphics gfx = Graphics.FromImage(Bmp))
    {
      // Turn off anti-aliasing and draw an exact copy
      gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
      gfx.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
      using (SolidBrush brush = new SolidBrush(Color.BlueViolet))
      {
        gfx.FillRectangle(brush, 0, 0, hw, hw);
      }
    }
    pictureBox1.Image = Bmp;
