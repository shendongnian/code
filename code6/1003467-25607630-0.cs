        DateTime timestamp;
        TimeSpan timeLeft;
        
        private void begin_timer()
        {
            timestamp = DateTime.Now;
            timer1.start();
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            timeLeft = DateTime.Now - timestamp;
            TimeLabel.Text = timeLeft.ToString("HH:mm:ss.fff");
        }
