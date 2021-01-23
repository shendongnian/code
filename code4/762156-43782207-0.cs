    public static bool TouchLeftOf(this Rectangle r1, Rectangle r2)
    {
        return (r1.Left <= r2.Right &&
                r1.Right >= r2.Right - 5 &&
                r1.Top <= r2.Bottom - (r2.Width / 4) &&
                r1.Bottom >= r2.Top + (r2.Width / 4));
    }
