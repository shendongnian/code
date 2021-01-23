    class FinalizerDelayer {
        ~FinalizerDelayer() {
            Console.WriteLine("Delaying finalizer...");
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("Delay done");
        }
    }
