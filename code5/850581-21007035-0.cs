    public class Program
    {
        private static readonly ManualResetEvent StopWriting = new ManualResetEvent(false);
        private static void Main(string[] args)
        {
            Thread t = new Thread(WriterFunc);
            t.Start();
            string input;
            do
            {
                input = Console.ReadLine();
            } while (input != "stop");
            // Tell the thread to stop writing
            StopWriting.Set();
            // And wait for the thread to exit
            t.Join();
        }
        private static void WriterFunc()
        {
            int index = 0;
            while (!StopWriting.WaitOne(Timeout.Infinite))
            {
                ++index;
                Console.WriteLine(index.ToString());
            }
        }
    }
