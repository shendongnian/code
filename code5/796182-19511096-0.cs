    using System.Threading;
    
    static class Foo
    {
        static long i;
        public static long GetUnique() { return Interlocked.Increment(ref i); }
    }
