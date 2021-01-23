    class Program
    {
        static void Main(string[] args)
        {
            var counter = new Counter();
            counter.CountUsingCallback(WriteProgress);
            Console.ReadKey();
        }
        private static void WriteProgress(int progress, int total){
            Console.WriteLine("Progress {0}/{1}", progress, total);
        }
    }
    public class Counter
    {
        public void CountUsingCallback(Action<int, int> callback)
        {
            for (int i = 0; i < 10; i++)
            {
                System.Threading.Thread.Sleep(1000);
                callback(i + 1, 10);
            }
        }
    }
