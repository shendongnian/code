      Timer t = new Timer();
        private void Form1_Load(object sender, EventArgs e)
        {
            t.Interval = 15000;
            t.Tick += new EventHandler(OnTimerTicked);
            t.Start();
        }
        public void OnTimerTicked(object sender, EventArgs e)
        {
            t.Stop();
            Form2 formdois = new Form2();
            form2.Show();
        }
