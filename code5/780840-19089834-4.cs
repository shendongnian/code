    public class MenuItemWithItalicFont : MenuItem
    {
        private Font font;
        public MenuItemWithItalicFont(string text)
            : base(text)
        {
            OwnerDraw = true;
            font = new Font("Arial", 10, FontStyle.Italic);
        }
        protected override void OnMeasureItem(MeasureItemEventArgs e)
        {
            var g = e.Graphics;
            e.ItemWidth = 200;
            var size = g.MeasureString(Text, font, e.ItemWidth);
            e.ItemHeight = (int)size.Height;
        }
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);
            var g = e.Graphics;
            var brush = new SolidBrush(e.ForeColor);
            g.DrawString(Text, font, brush, e.Bounds.X, e.Bounds.Y);
        }
    }
