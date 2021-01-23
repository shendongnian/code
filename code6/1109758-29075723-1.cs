    There nothing to do. Just create an object instance on Form2 with required number of Parameters for passing the values to Form2
    
        private void button1_Click(object sender, EventArgs e)
                {
                    Form2 f2 = new Form2(textBox1.Text);            
                    f2.Show();
                }
        
        
        public Form2(string value)
                {
                    InitializeComponent();
                    textBox2.Text = value;
                }
