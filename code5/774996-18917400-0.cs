        public Form1()
        {
            InitializeComponent();
            panel1.MouseEnter += new EventHandler(panel1_MouseEnter);
            panel1.MouseLeave += new EventHandler(panel1_MouseLeave);
        }
        void panel1_MouseLeave(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Red;
        }
        void panel1_MouseEnter(object sender, EventArgs e)
        {
            panel1.BackColor = Color.PaleGoldenrod;
        }
