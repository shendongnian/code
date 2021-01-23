    static class AutoIncrement
    {
        private static long num;
        public static long Current
        {
            get
            {
                return Interlocked.Increment(ref num);
            }
        }
    }
    Console.WriteLine(AutoIncrement.Current);
    Console.WriteLine(AutoIncrement.Current);
    Console.WriteLine(AutoIncrement.Current);
    Console.WriteLine(AutoIncrement.Current);
    Console.WriteLine(AutoIncrement.Current);
