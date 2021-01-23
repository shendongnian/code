        private bool Timing = false;
        private void button1_Click(object sender, EventArgs e)
        {
            Timing = true;
            Thread th1 = new Thread(updatetimer);
            th1.IsBackground = true;
            th1.Start();
            secret = a.Next(0, 101);
            counter = 0;
            label2.Text = "";
            button1.Enabled = false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Timing = false;
            button1.Enabled = true;
        }
        public void updatetimer()
        {
            Stopwatch aa = Stopwatch.StartNew();
            TimeSpan ts;
            while (Timing)
            {
                ts = aa.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}:{3:000}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
                this.Invoke((MethodInvoker)delegate
                {
                    label3.Text = elapsedTime;
                });
                System.Threading.Thread.Sleep(50);
            }
        }
