    void item_MeasureItem(object sender, MeasureItemEventArgs e)
    {
        var item = (MenuItem)sender;
        var g = e.Graphics;
        Font font = new Font("Arial", 10, FontStyle.Italic);
            
        e.ItemWidth = 200;
        var size = g.MeasureString(item.Text, font, e.ItemWidth);
        e.ItemHeight = (int)size.Height;            
    }
    void item_DrawItem(object sender, DrawItemEventArgs e)
    {
        var item = (MenuItem)sender;
        var g = e.Graphics;            
        var font = new Font("Arial", 10, FontStyle.Italic);
        var brush = new SolidBrush(e.ForeColor);
        g.DrawString(item.Text, font, brush, e.Bounds.X, e.Bounds.Y);
    }
