        public Color GetColorFromScreen(Point p)
        {
            Rectangle rect = new Rectangle(p, new Size(2, 2));
            Bitmap map = CaptureFromScreen(rect);
            Color c = map.GetPixel(0, 0);
            map.Dispose();
            return c;
        }
