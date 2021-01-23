    using System;
    using System.Diagnostics;
     
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Stopwatch();
            s.Start();
            int a = 0;
            for (int i = 0; i < 100000000; i++)
            {
                a = Fibonacci(45);
            }
            s.Stop();
            Console.WriteLine(s.ElapsedMilliseconds);
        }
     
        public static int Fibonacci(int n)
        {
            int a = 0;
            int b = 1;
            for (int i = 0; i < n; i++)
            {
                int temp = a;
                a = b;
                // if the JIT compiler is clever, only this one needs to be 'checked'
                b = temp + b; 
            }
            return a;
        }
     
    }
