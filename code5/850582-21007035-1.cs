    public class Program
    {
        private static readonly ManualResetEvent StopWriting = new ManualResetEvent(false);
        private static void Main(string[] args)
        {
            Thread t = new Thread(ReaderFunc);
            t.Start();
            int index = 0;
            while (!StopWriting.WaitOne(Timeout.Infinite))
            {
                ++index;
                Console.WriteLine(index.ToString());
            }
            // Wait for the background thread to exit
            t.Join();
        }
        private static void ReaderFunc()
        {
            string input;
            do
            {
                input = Console.ReadLine();
            } while (input != "stop");
            // Tell the main thread to stop writing
            StopWriting.Set();
        }
    }
