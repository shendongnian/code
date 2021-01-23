        void Main()
        { 
            Timer timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 30000; //How often you want to show the tooltip?
            timer.Enabled = true;
        }
        void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            Application.SetSuspendState(PowerState.Suspend, false, false);
        }
        void timer_Tick(object sender, EventArgs e)
        {
            notifyIcon1.ShowBalloonTip(10000);
        }
