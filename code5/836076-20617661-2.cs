    class MyPanel : Panel
    {
        private Rectangle? paintedRectangle = null;
        public void PopuplateTable(int x, int y)
        {
            paintedRectangle = new Rectangle(x, y, 100, 40);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (paintedRectangle.HasValue)
            {
                using (var b = new SolidBrush(Color.DarkCyan))
                {
                    e.Graphics.FillRectangle(b, paintedRectangle.Value);
                }
            }
        }
    }
