        **Constructor**
        public Form1() 
        {
            InitializeComponent();
            button2.Click += new EventHandler(button1_Click);
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox1.Text);
        }
