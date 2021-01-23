        public string Form1Text1Text { get; set; }
        public Form2()
        {
            InitializeComponent();
        }
       private void button1_Click(object sender, EventArgs e)
        {
            var f2 = new Form2();
            f2.Form1Text1Text = textBox1.Text;
            f2.ShowDialog();
        }
