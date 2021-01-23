    class MyTextDrawer 
    {
        private readonly Graphics g;
        public MyTextDrawer(Graphics g) 
        {
            this.g = g;
        }
        public void DrawText(string text, Color pen_color, Color brushes_color, Point point1, Point point2, Point point3,
                              double font_size)
        {
            this.Font = new Font(this.Font.FontFamily.Name, (float)font_size);
            SolidBrush brush = new SolidBrush(brushes_color);
            using (Pen pen = new Pen(pen_color, 10f))
            {
                Point pt1 = point1;
                Point pt2 = point2;
                g.DrawLine(pen, point1, point2);
            }
            g.DrawString(text,
                    this.Font, brush, point3);
        }
            
    }
