    using (Graphics gfx = Graphics.FromImage(pictureBox1.Image))
    {
      // Turn off anti-aliasing and draw an exact copy
      gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
      gfx.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
      using (SolidBrush brush = new SolidBrush(Color.BlueViolet))
      {
        gfx.FillRectangle(brush, 0, 0, 
                          pictureBox11.Width - 1, 
                          pictureBox11.Height - 1);
      }
    }
    
    // Force the picturebox to redraw with the new image.
    // You could also use pictureBox11.Refresh() to do the redraw.
    pictureBox11.Invalidate();
