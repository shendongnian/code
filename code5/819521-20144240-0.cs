        DateTime startTime;
        private void button1_Click(object sender, EventArgs e)
        {
            timer.Tick += (s, ev) => { label1.Text = String.Format("{0:00}", (DateTime.Now - startTime).Seconds); };
            startTime = DateTime.Now;
            timer.Interval = 100;       // every 1/10 of a second
            timer.Start();
        }   
