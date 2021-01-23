        System.Timers.Timer timer1 = new System.Timers.Timer();
        timer1.Interval=1000;//one second
        timer1.Elapsed += new System.Timers.ElapsedEventHandler(timer1_Tick);
        timer1.Start();
        char ch;
        private void timer1_Tick(object sender, System.Timers.ElapsedEventArgs e)
        {
            ch=Console.ReadKey().KeyChar;
            //stop the timer whenever needed
            //timer1.Stop();
        }
