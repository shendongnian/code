            private BindingSource bs;
    
            public Form1()
            {
                InitializeComponent();
                bs = new BindingSource();
                bs.DataSource = Properties.Settings.Default.Combovalues;
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                comboBox1.DataSource = bs;
            }
    
            //button1 is for adding values.
            private void button1_Click(object sender, EventArgs e)
            {
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    bs.Add(textBox1.Text);
                }
            }
    
            private void Form1_FormClosing(object sender, FormClosingEventArgs e)
            {
                //this will persist to disk the changes made
                //in this application session.
                Properties.Settings.Default.Save();
            }
    
            //button2 is for deleting values
            private void button2_Click(object sender, EventArgs e)
            {
                //removes the currently selected item in the combobox.
                bs.RemoveCurrent();
            }
