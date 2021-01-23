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
            return x == PositiveInfinity;
        }
        public static bool IsNegativeInfinity(this int x)
        {
            return x == NegativeInfinity;
        }
        public static int Operation(this int x, int y)
        {
            // ...
            return PositiveInfinity;
        }
    }
