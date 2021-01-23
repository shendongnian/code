        public string name 
        { get; 
            set
            {
                if (value != "Hello")
                    MessageBox.Show("Blah");
                else
                { name = value; }
            }
        }
    private void button1_Click(object sender, EventArgs e)
        {
            name = textbox_Name.Text;
        }
    
