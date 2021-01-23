    public Brush myBrush = null;
    private void pb_cover_Paint(object sender, PaintEventArgs e)
    {
        if (pb_cover.Image == null)
        {
            Size  s = pb_cover.ClientSize;
            e.Graphics.FillRectangle(myBrush, 0, 0, s.Width, s.Height);
            e.Graphics.DrawLine(Pens.Red, 0, 0, s.Width, s.Height);
            e.Graphics.DrawLine(Pens.Red, s.Height, 0, 0, s.Width);
        }
    }
