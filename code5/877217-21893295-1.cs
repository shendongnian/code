        private static int MeasureTextWidth(Control c, string text)
        {
            if (c == null)
            { return -1; }
            using (Graphics g = c.CreateGraphics())
            {
                return (int)Math.Ceiling(g.MeasureString(text, c.Font).Width);
            }
        }
