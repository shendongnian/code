    public static class Extensions
    {
        public static int HighestOneBit(this int number)
        {
            return (int)Math.Pow(2, Convert.ToString(number, 2).Length - 1);
        }
    }
