        private void Form1_Load(object sender, EventArgs e)
        {
            Timer T = new Timer() { Interval = 1000, Enabled=true };
            T.Tick += T_Tick;
            T_Tick(this, EventArgs.Empty);
        }
        void T_Tick(object sender, EventArgs e)
        {
            DateTime d = DateTime.Now;
            textBox1.Text = d.ToString();
        }
