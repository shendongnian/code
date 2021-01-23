        public Form1()
        {
            InitializeComponent();
            numericUpDown1.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.numericUpDown1_MouseWheel);
        }
        private void numericUpDown1_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            MessageBox.Show("hello");
        }
