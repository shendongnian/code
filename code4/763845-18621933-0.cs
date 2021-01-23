        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 SecondaryForm = new Form2(this);
            SecondaryForm.ShowDialog();
        }
        public void updateText(string txt)
        {
            textBox1.Text = txt;
        }
