    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        int xx = panel1.HorizontalScroll.Value;
        int yy = panel1.VerticalScroll.Value;
        e.Graphics.FillRectangle(Brushes.Wheat, new Rectangle(11 - xx, 22 - yy, 22, 311));
        e.Graphics.FillRectangle(Brushes.RosyBrown, new Rectangle(11 - xx, 280 - yy, 22, 3));
    }
    private void panel1_Scroll(object sender, ScrollEventArgs e)
    {
        panel1.Invalidate();
    }
