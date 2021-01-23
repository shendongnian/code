    public static class GlobalCounter
    {
        public static int Value { get; private set; }
        public static void Increment()
        {
            Interlocked.Increment(ref Value);
        }
        public static void Reset()
        {
            Interlocked.Exchange(ref Value, 0);
        }
    }
