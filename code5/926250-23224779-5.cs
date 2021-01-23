    class Program
    {
        public static IEnumerable<long> Fibonacci(int n)
        {
            long a = 0;
            long b = 1;
            for (int i = 0; i < n; i++)
            {
                yield return a;
                long sum = a;
                a = b;
                b = sum + b;
            }
        }
        static void Main()
        {
            MessageBox.Show(string.Join(System.Environment.NewLine, Fibonacci(12)));
        }
}
