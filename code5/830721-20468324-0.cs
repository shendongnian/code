        Thread runner;
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            timer1.Interval = 1000;
            textBox1.Text = "Amazing"; // initial process
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (runner != null && runner.IsAlive)
                return;
            runner = new Thread(new ThreadStart(() =>
            {
                // run your process here
                Thread.Sleep(5000);
                StopRunner();
            }));
            runner.Start();
        }
        private void StopRunner()
        {
            timer1.Stop();
            // post process here
        }
