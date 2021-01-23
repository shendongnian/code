        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            ...
            Timer timer = new Timer(5000); //5000 milisecs - 5 secs
            timer.Elapsed += timer_Elapsed;
            timer.Start();
            ...
        }
        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            //your code here
        }
