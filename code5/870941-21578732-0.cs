        private int time = 60;
        DateTime dt = new DateTime();
        private int j = 15;
        private Timer timer1 = new Timer();
        void timer_tick(object sender, EventArgs e)
        {
            if (time > 0)
            {
                time--;
                text.Text = TimeSpan.FromSeconds(time).ToString();
            }
            else
            {
                timer1.Stop();
            }
        }
        public timer()
        {
            InitializeComponent();
            timer1 = new Timer();
            timer1.Interval = 1000;
            timer1.Tick += timer_tick;
            timer1.Start();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            time += j;
        }
