    public static class GlobalCounter
    {
        public static int Value { get; private set; }
        public static void Increment()
        {
            Value = GetNextValue(Value);
        }
        private static int GetNextValue(int curValue)
        {
            return Interlocked.Increment(ref curValue);
        }
        public static void Reset()
        {
            Value = 0;
        }
    }
