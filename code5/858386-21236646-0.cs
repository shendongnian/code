    internal class Program
    {
        private static void Main(string[] args)
        {
            var m1 = Task.Factory.StartNew(() => Method1());
            var m2 = Task.Factory.StartNew(() => Method2());
            var val = m1.Result || m2.Result;
            Console.WriteLine(val);
            Console.ReadLine();
        }
        private static bool Method1()
        {
            Thread.Sleep(1000);
            Console.WriteLine(1);
            return false;
        }
        private static bool Method2()
        {
            Thread.Sleep(3000);
            Console.WriteLine(2);
            return true;
        }
    }
