    class Program
    {
        static void Main(string[] args)
        {
            var counter = new Counter();
            counter.ProgessTick += WriteProgress;
            counter.CountUsingEvent();
            Console.ReadKey();
        }
        private static void WriteProgress(int progress, int total){
            Console.WriteLine("Progress {0}/{1}", progress, total);
        }
    }
    public class Counter
    {
        public event Action<int, int> ProgessTick;
        public void CountUsingEvent()
        {
            for (int i = 0; i < 10; i++)
            {
                System.Threading.Thread.Sleep(1000);
                if (ProgessTick != null)
                    ProgessTick(i + 1, 10);
            }
        }
    }
