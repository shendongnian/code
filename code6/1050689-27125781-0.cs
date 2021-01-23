    using System;
    using System.Threading.Tasks;
    namespace Demo
    {
        public static class Program
        {
            [STAThread]
            private static void Main()
            {
                var task = test();
                Console.WriteLine(task.Result);
            }
            private static Task<int> test()
            {
                return Task<int>.Factory.StartNew(() =>
                {
                    int x = 10;  // <-- Set a breakpoint here.
                    int y = 5;
                    int z = x/y;
                    return z;
                });
            }
        }
    }
