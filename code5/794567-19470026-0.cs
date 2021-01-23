    public bool Contains (RectangleF rect)
    {
        return rect == RectangleF.Intersect (this, rect);
    }
    public static RectangleF Intersect (RectangleF a, RectangleF b)
    {
        if (!a.IntersectsWithInclusive (b))
        {
            return RectangleF.Empty;
        }
        return RectangleF.FromLTRB (Math.Max (a.Left, b.Left), Math.Max (a.Top, b.Top), Math.Min (a.Right, b.Right), Math.Min (a.Bottom, b.Bottom));
    }
    private bool IntersectsWithInclusive (RectangleF r)
    {
        return this.Left <= r.Right && this.Right >= r.Left && this.Top <= r.Bottom && this.Bottom >= r.Top;
    }
    public static RectangleF FromLTRB (float left, float top, float right, float bottom)
    {
        return new RectangleF (left, top, right - left, bottom - top);
    }
