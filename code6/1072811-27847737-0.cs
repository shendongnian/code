        BackgroundWorker blinker;
        public Form1()
        {
            InitializeComponent();
            blinker = new BackgroundWorker();
            blinker.DoWork += blinker_DoWork;
        }
        private void blinker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                System.Threading.Thread.Sleep(1000); // Set fast to slow.
                if (label1.InvokeRequired)
                {
                    label1.Invoke((Action)blink);
                }
                else
                {
                    blink();
                }
            }
        }
        private void blink()
        {
            if (label1.BackColor == Color.Red)
                label1.BackColor = Color.Transparent;
            else
                label1.BackColor = Color.Red;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (blinker.IsBusy == false)
            {
                blinker.RunWorkerAsync();
            }
        }
