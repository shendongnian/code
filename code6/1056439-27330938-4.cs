    int cols = 7; int rows = 11;
    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        Rectangle Rect = // your Rectangle!
        Rectangle pRect = Rect;  // panel2.ClientRectangle;
        float width = 1f * pRect.Width / cols;
        float height = 1f * pRect.Height / rows;
        using (Pen pen = new Pen(System.Drawing.Color.Blue, 1))
        {
          pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
          for (int c = 0; c < cols; c++)
             for (int r = 0; r < rows; r++)
             {
                RectangleF rect = new RectangleF(pRect.X + c * width, pRect.Y + r * height, 
                                                 width, height);
                e.Graphics.FillRectangle(Brushes.Coral, rect);
                // e.Graphics.DrawRectangle(pen, rect.X, rect.Y, rect.Width, rect.Height);
             }
            for (int c = 0; c < cols; c++) e.Graphics.DrawLine(pen, 
                 pRect.X + c * width, pRect.Y, pRect.X + c * width, pRect.Y + pRect.Height);
            for (int r = 0; r < rows; r++) e.Graphics.DrawLine(pen, 
                 pRect.X, pRect.Y + r * height, pRect.X + pRect.Width, pRect.Y + r * height);
            e.Graphics.DrawRectangle(Pens.Red, 
                                     pRect.X, pRect.Y, pRect.Width - 1, pRect.Height - 1);
        }
    }
