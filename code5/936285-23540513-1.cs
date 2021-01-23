    public class ConsoleProgressObserver : IProgressObserver
    {
        public void NotifyProgress(double done)
        {
            Console.WriteLine("Progress: {0:0.00}%", done * 100);
        }
    }
