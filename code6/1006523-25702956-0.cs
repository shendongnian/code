    private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            Form2 f2 = new Form2(textBox1.Text);
            this.Hide();
            f2.ShowDialog();
            this.Close();
    
        }
    }
    
        public Form2(string s)
        {
            InitializeComponent();
            label1.Text = s;
        }
