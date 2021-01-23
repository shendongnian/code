    public static class OverflowExtensions
    {
        public static bool WillAdditionOverflow(this byte b, int val)
        {
            return byte.MaxValue - b < val;
        }
        
        public static bool WillSubtractionUnderflow(this byte b, int val)
        {
            return b - byte.MinValue < val;
        }
    }
