    internal class Program
    {
        private static void Main(string[] args)
        {
            var cm2 = new CancellationTokenSource();
            var m1 = Task.Factory.StartNew(() => Method1());
            var m2 = Task.Factory.StartNew(() => Method2(cm2.Token), cm2.Token);
            var val = m1.Result || m2.Result;
            cm2.Cancel();
            
            Console.WriteLine(val);
            Console.ReadLine();
        }
        private static bool Method1()
        {
            Thread.Sleep(1000);
            Console.WriteLine(1);
            return true;
        }
        private static bool Method2(CancellationToken token)
        {
            Thread.Sleep(3000);
            if (token.IsCancellationRequested)
                return false;
            Console.WriteLine(2);
            return true;
        }
    }
