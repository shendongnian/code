    List<Point> PointsInCircle(int diameter)
    {
        List<Point> points = new List<Point>();
        Color black = Color.FromArgb(255, 0, 0, 0);
        using (Bitmap bmp = new Bitmap(diameter, diameter))
        using (Graphics g = Graphics.FromImage(bmp))
        {
            g.Clear(Color.White);
            g.FillEllipse(Brushes.Black, 0, 0, diameter, diameter);
            for (int y = 0; y < diameter; y++)
                for (int x = 0; x < diameter; x++)
                    if (bmp.GetPixel(x, y) == black) points.Add(new Point(x, y));
        }
        return points;
    }
