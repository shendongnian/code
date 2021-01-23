        bool Play_On = false;
        int i = 0;
        Timer MinResTimer;
        private void Form1_Load(object sender, EventArgs e)
        {
            MinResTimer = new Timer();
            {
                MinResTimer.Tick += new EventHandler(MinResTimer_Elapsed);
                MinResTimer.Interval = 2000;
                MinResTimer.Enabled = true;
                MinResTimer.Start();
            }
        }
        void MinResTimer_Elapsed(object sender, EventArgs e)
        {
            if (Play_On == true && i <= 4)
            {
                i++;
                MessageBox.Show("timed" + i.ToString());
            }
            if (i == 4)
            {
                Play_On = false;
                button1.Text = "Pause";
            }
        }  
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Play")
            {
                button1.Text = "Puase";
                Play_On = true;
            }
            else
            {
                button1.Text = "Play";
                Play_On = false;
            }
        }
