    class Program
    {
        static System.Timers.Timer timer1 = new System.Timers.Timer();
        static void Main(string[] args)
        {
            timer1.Interval = 1000;//one second
            timer1.Elapsed += new System.Timers.ElapsedEventHandler(timer1_Tick);
            timer1.Start();
            Console.WriteLine("Press \'q\' to quit the sample.");
            while (Console.Read() != 'q') ;
        }
        static private void timer1_Tick(object sender, System.Timers.ElapsedEventArgs e)
        {
            //do whatever you want 
            Console.WriteLine("I'm Inside Timer Elapsed Event Handler!");
        }
    }
