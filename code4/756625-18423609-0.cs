        System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();
        void CreateTimer()
        {
            _timer = new System.Windows.Forms.Timer();
            _timer.Tick += new EventHandler(_timer_Tick);
            _timer.Interval = 5000;
            _timer.Enabled = true;
        }
        void _timer_Tick(object sender, EventArgs e)
        {
            // do something.
        }
