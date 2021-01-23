    class Program
    {
        static System.Threading.Timer testtimer;
        static void Main(string[] args)
        {
            testtimer = new System.Threading.Timer(testtimertick);
            testtimer.Change(5000,0);
          
            while (true)
            {
                Application.DoEvents();  //Prevents application from exiting
            }
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
            testtimer.Change(5000, 0);
        }
    }
