    int cols = 7; int rows = 11;
    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        Size pSize = panel1.ClientSize;
        float width = 1f * pSize.Width / cols;
        float height = 1f * pSize.Height / rows;
        for (int c = 0; c < cols; c++ )
            for (int r = 0; r < rows; r++)
            {
                RectangleF rect = new RectangleF(c*width, r*height, width, height);
                e.Graphics.FillRectangle(Brushes.Coral, rect);
                e.Graphics.DrawRectangle(Pens.Blue, rect.X, rect.Y, rect.Width, rect.Height);
            }
        e.Graphics.DrawRectangle(Pens.Red, 0, 0, pSize.Width - 1, pSize.Height - 1);
    }
