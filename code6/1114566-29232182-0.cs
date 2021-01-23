    public static class Prime
    {
        public static IEnumerable<int> Values() 
        {
            var ints = Enumerable.Range(2, Int32.MaxValue - 1);
            return ints.Where(x => !ints.TakeWhile(y => y < Math.Sqrt(x)).Any(y => x % y == 0));
        }
    }
