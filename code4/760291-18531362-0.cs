        Timer tmr = new Timer();
        public Form1()
        {
            InitializeComponent();
            tmr.Tick += new EventHandler(tmr_Tick);
        }
        void tmr_Tick(object sender, EventArgs e)
        {
            if (ActiveForm == this)
                SendKeys.Send("{A}");
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            tmr.Start();
        }
