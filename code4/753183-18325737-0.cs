    public class Factorial
    {
        public static ulong Compute(ulong n)
        {
            if (n == 0)
                return 1;
            return n * Factorial.Compute(n - 1);
        }
    }
