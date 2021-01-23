        public static IEnumerable<double> FibList(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                yield return Math.Round(Fib(i));
            }
        }
        public static double Fib(double n)
        {
            double golden = 1.61803398875;
            return (n == 0 || n == 1) ? 1 : (Math.Pow(golden, n) - Math.Pow(-golden, -n))/Math.Sqrt(5);
        }
