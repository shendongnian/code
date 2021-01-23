    Timer timer = new Timer();
    private void button1_Click(object sender, EventArgs e)
            {                
                timer.Interval = 30000; // here time in milliseconds
                timer.Tick += timer_Tick;
                timer.Start();
                button1.Enabled = false;
            }
    
            void timer_Tick(object sender, EventArgs e)
            {
                button1.Enabled = true;
                timer.Stop();
            }
