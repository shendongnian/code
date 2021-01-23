        private void Form3_Load(object sender, EventArgs e)
        {
            SetLabel1Text(); //reset label text
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
            SetLabel1Text();
            if (StopTime == 4)
            {
                StopTime = 0;
                timer2.Stop();
            }
        }
        private void SetLabel1Text()
        {
            string[] label1Text = { "  Connecting to smtp server..", "  Connecting to smtp server..", "     Fetching recipients..", "  Attaching G-code files..", "                Done!!" };
            label1.Text = label1Text[StopTime]; //populate label from array of values
        }
