    public class StaticVariableTester
    {
        private static int count;
        public static void Add(int i)
        {
            Interlocked.Add(ref count, i);
        }
        public static int Count
        {
            get { return count; }
        }
    }
