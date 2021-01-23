    using System.Threading;
    ...
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting");
            var timer = new Timer(TimerCallBack, null, 0, 60000); // change 60000 to 6000 for faster testing!
            Console.ReadLine();
        }
        static void TimerCallBack(object o)
        {
            spendTime();
        }
        static void spendTime()
        {
            Console.WriteLine("spent time" + DateTime.Now.ToString());
            return;
        }
    }
