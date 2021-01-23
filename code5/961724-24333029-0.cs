    private Point SnapToGrid(Point p)
    {
        double x = Math.Round((double)p.X / xsize) * xsize;
        double y = Math.Round((double)p.Y / ysize) * ysize;
        return new Point((int)x, (int)y);
    }
