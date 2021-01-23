    public interface ILala
    {
        void DoLala();
    }
    public class LalaStaticImpl : ILala
    {
        private static int _counter;
        public void DoLala()
        {
            _counter++;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Message("Compiling dynamic lala...");
            var lala = BuildDynamicLala();
            Message("Testing dynamic lala...");
            Test(lala);
            Message("Sleeping for 1s...");
            GC.Collect();
            Thread.Sleep(1000);
            Message("Testing static lala...");
            Test(new LalaStaticImpl());
        }
        private static void Test(ILala lala)
        {
            var watch = Stopwatch.StartNew();
            for (var i = 0; i < 1000000000; i++)
                lala.DoLala();
            Console.WriteLine(watch.Elapsed);
        }
    }
