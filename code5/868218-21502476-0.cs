        class Program
        {
            static  System.Timers.Timer timer1 = new System.Timers.Timer();
            int intCheckRowCount =0;
            static void Main(string[] args)
            {
                timer1.Interval = 20000;//20 seconds
                timer1.Elapsed += new System.Timers.ElapsedEventHandler(timer1_Tick);
                timer1.Start();                
            }
            static private void timer1_Tick(object sender, System.Timers.ElapsedEventArgs e)
            {
                intCheckRowCount = Database.DataExists();
                if(intCheckRowCount ==0)
                timer1.Stop();
            }
        }
