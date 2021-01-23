    public class Program
    {
        const int innerMax = 100;
        const int outerMax = 1000;
    
        public static void Main()
        {
            var t1 = new TimeSpan();
            var t2 = new TimeSpan();
    
            var program = new Program();
    
            for (int i = 0; i < outerMax; i++)
                t1 = program.InstanceAction();
    
            for (int i = 0; i < outerMax; i++)
                t2 = StaticAction();
    
            Console.WriteLine("t1 = {0} ms (instance)", t1.TotalMilliseconds);
            Console.WriteLine("t2 = {0} ms (static)", t2.TotalMilliseconds);
            Console.ReadLine();
        }
    
        private TimeSpan InstanceAction()
        {
            return Time(() => {
                var sw = new SpinWait();
                for (int i = 0; i < max; i++)
                    sw.SpinOnce();
            });
        }
    
        private static TimeSpan StaticAction()
        {
            return Time(() => {
                var sw = new SpinWait();
                for (int i = 0; i < innerMax; i++)
                    sw.SpinOnce();
            });
        }
    
        private static TimeSpan Time(Action action)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            action();
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }
    }
