    class Program
    {
        static System.Threading.Timer testtimer;
        static void Main(string[] args)
        {
            testtimer = new System.Threading.Timer(testtimertick);
            testtimer.Change(5000,0);
          
            Console.ReadLine();
        }
        private static void testtimertick(object sender)
        {
            Thread t = new Thread(dostuff);
            t.Start();
        }
        private static void dostuff()
        {
            //Executes some code
            Thread.Sleep(2000);
            Console.WriteLine("Tick");
            testtimer.Change(5000, 0);
        }
    }
