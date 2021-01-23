    /// <summary>
    /// Making int infinity
    /// ...
    /// </summary>
    public static class IntExtension
    {
        public const int PositiveInfinity = int.MaxValue;
        public const int NegativeInfinity = int.MinValue;
        public static bool IsPositiveInfinity(this int x)
        {
            return x == int.MaxValue;
        }
        public static bool IsNegativeInfinity(this int x)
        {
            return x == int.MinValue;
        }
        public static int operator +(int x, int y)
        {
            if (x.IsPositiveInfinity() || y.IsPositiveInfinity())
            {
                return PositiveInfinity;
            }
            else if (x.IsNegativeInfinity() || y.IsNegativeInfinity())
            {
                return NegativeInfinity;
            }
            else
            {
                return x + y;
            }
        }
    }
