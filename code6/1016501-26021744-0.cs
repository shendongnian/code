        private System.Timers.Timer timer;
        private void scanBox_TextChanged(object sender, EventArgs e)
        {
            if (scanBox.Text.Length == 10)
            {
                //wait for 10 chars and then set the timer
                timer = new System.Timers.Timer(2000); //adjust time based on time required to enter the last 3 chars 
                timer.Elapsed += OnTimedEvent;
                timer.Enabled = true;
            }
        }
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            timer.Enabled = false;
            if (scanBox.Text.Length == 10)
            {
                getRecord10();                
            }
            else if (scanBox.Text.Length == 13)
            {
                getRecord13();
            }
            else
            {
                MessageBox.Show("Not in directory", "Error");
            }
        }
