    public static class IntegerExtensions
    {
        public static int DivideWholeAndPartial(this int total, int divisor)
        {
            return (int)Math.Ceiling((double)total / (double)divisor);
        }
    }
