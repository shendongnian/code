    int cols = 7; int rows = 11;
    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        int width = panel1.ClientSize.Width / cols;
        int height = panel1.ClientSize.Height / rows;
        for (int c = 0; c < cols; c++ )
            for (int r = 0; r < rows; r++)
            {
                Rectangle rect = new Rectangle(c * width, r * height, width, height);
                e.Graphics.FillRectangle(Brushes.Coral, rect);
                e.Graphics.DrawRectangle(Pens.Blue, rect);
            }
     }
