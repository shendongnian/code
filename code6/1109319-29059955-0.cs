     public Form1()
        {
            InitializeComponent();
            Timer timer = new Timer();
            timer.Interval = 12;
            timer.Tick += timer_Tick;
            timer.Start();
        }
        int difference = 5;
        void timer_Tick(object sender, EventArgs e)
        {
            if (pictureBox1.Left  < 0 || pictureBox1.Left + pictureBox1.Width > this.Width) difference = -difference;
            pictureBox1.Left += difference;
        }
