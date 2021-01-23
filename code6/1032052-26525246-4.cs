       public Form1()
        {
            InitializeComponent();
            this.Text = "";
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            switchSaverState(false);
        }
        Point lastMosePosition = Point.Empty;
        int savingWaitMinutes = 10;
        int minute = 60000;
        Timer timer1 = new Timer;
        void switchSaverState(bool saving)
        {
            if (saving)
            {
                this.BackColor = Color.Black;
                this.Opacity = 0.8;
            }
            else
            {
                this.TransparencyKey = Color.Fuchsia;
                this.BackColor = Color.Fuchsia;
                this.Opacity = 1;
                timer1.Interval = minute * savingWaitMinutes;
                timer1.Start();
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timer1.Interval == minute * savingWaitMinutes)
            {
                timer1.Interval = 100;
                switchSaverState(true);
                lastMosePosition = Cursor.Position;
            }
            else
            {
                if (Cursor.Position != lastMosePosition)  { switchSaverState(false); }
            }
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            lastMosePosition = Cursor.Position;
            switchSaverState(false);
        }
