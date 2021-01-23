        private void Form1_Load(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timer.Tick += timer_Tick;
        }
        void timer_Tick(object sender, EventArgs e)
        {
            // Do your thing
        }
