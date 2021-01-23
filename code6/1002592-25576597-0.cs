            public Form1()
            {
                InitializeComponent();
                textBox1.LostFocus += new EventHandler(textBox1_LostFocus);
                textBox1.GotFocus += new EventHandler(textBox1_GotFocus);
                
            }
    
            void textBox1_GotFocus(object sender, EventArgs e)
            {
                listBox1.Visible = true;
            }
    
            void textBox1_LostFocus(object sender, EventArgs e)
            {
                if(!listBox1.Focused)
                   listBox1.Visible = false;
            }
    
            private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
            {
                textBox1.Text = listBox1.SelectedItem.ToString();
            }
    
            private void Form1_Shown(object sender, EventArgs e)
            {
                //if your textbox as focus when the form shows
                //this is the place to switch focus to another control
                
                listBox1.Visible = false;
            }
