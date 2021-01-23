    using System;
    using System.Threading;
    using System.Threading.Tasks;
     
    class Test
    {
        static void Main()
        {
            var wtoken = new CancellationTokenSource();
            var readInputStream = Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(i);
                    Thread.Sleep(200);
                }
            }, wtoken.Token);
            Console.ReadLine();
        }
    }
