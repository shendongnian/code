    int cols = 7; int rows = 11;
    private void panel1_Paint(object sender, PaintEventArgs e)
    {
      Size pSize = panel1.ClientSize;
      float width = 1f * pSize.Width / cols;
      float height = 1f * pSize.Height / rows;
       using (Pen pen = new Pen(System.Drawing.Color.Blue, 1))
       {
        pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
        for (int c = 0; c < cols; c++ )
          for (int r = 0; r < rows; r++)
          {
             RectangleF rect = new RectangleF(c * width, r * height, width, height);
             e.Graphics.FillRectangle(Brushes.Coral, rect);
             // e.Graphics.DrawRectangle(Pens.Blue, rect.X, rect.Y, rect.Width, rect.Height);
          }
       // for DashStyle, don't draw overlapping rectangles!   
       for (int c = 0; c < cols; c++) e.Graphics.DrawLine(pen, 
                                                 c * width, 0, c * width, pSize.Height);
       for (int r = 0; r < rows; r++) e.Graphics.DrawLine(pen, 
                                                 0, r * height, pSize.Width, r * height);
       e.Graphics.DrawRectangle(Pens.Red, 0, 0, pSize.Width - 1, pSize.Height - 1);
     }
    }
