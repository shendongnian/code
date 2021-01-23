    class Program {
        static void Main(string[] args) {
            var target1 = new Example(1);
            var target2 = new Example(2);
            var shortweak = new WeakReference(target1);
            var longweak = new WeakReference(target2, true);
            var delay = new FinalizerDelayer();
            GC.Collect();       // Kills short reference
            Console.WriteLine("Short alive = {0}", shortweak.IsAlive);
            Console.WriteLine("Long  alive = {0}", longweak.IsAlive);
            GC.WaitForPendingFinalizers();
            Console.WriteLine("Finalization done");
            GC.Collect();       // Kills long reference
            Console.WriteLine("Long  alive = {0}", longweak.IsAlive);
            Console.ReadLine();
        }
    }
