         private void Form3_Load(object sender, EventArgs e)
        {
            timer1.Interval = 5000;
            timer1.Enabled = true;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer2.Interval = 1000;
            timer2.Start();
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            timer1.Stop();
        }
        int StopTime = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            StopTime++;
            if (StopTime == 1)
            {
                label1.Text = "  Connecting to smtp server..";
            }
            if (StopTime == 2)
            {
                label1.Text = "     Fetching recipients..";
            }
            if (StopTime == 3)
            {
                label1.Text = "  Attaching G-code files..";
            }
            if (StopTime == 4)
            {
                label1.Text = "                Done!!";
                StopTime = 0;
                timer2.Stop();
            }
        }
