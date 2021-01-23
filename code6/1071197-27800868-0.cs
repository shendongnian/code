    class Program
    {
        static int value = 1;
        static void Main(string[] args)
        {
            Task t1 = Task.Run(() =>
            {
                Interlocked.CompareExchange(ref value, 2, 1);
            });
            Task t2 = Task.Run(() =>
            {
                value = 3;
            });
            Task.WaitAll(t1, t2);
            Console.WriteLine(value);
        }
    }
