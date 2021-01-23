    using System.Timers;
    class myclass
    {
        System.Timers.Timer timer;
        public void initialise()
        {
            timer = new System.Timers.Timer(10000);
            timer += new ElapsedEventHandler(_timer_Elapsed);
        }
        
        void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
	    timeHours.Text = DateTime.Now.Hour.ToString();
        }
    } 
