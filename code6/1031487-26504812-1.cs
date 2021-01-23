        Label labelOne = null;
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(ref Label lbl)
        {
            InitializeComponent();
            labelOne = lbl;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            labelOne.Text = "A";
        }
