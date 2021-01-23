    public static class IntExtensions
    {
        // min inclusive, max exclusive
        public static bool IsBetween(this int source, int min, int max)
        {
            return source >= min && source < max
        }
    }
