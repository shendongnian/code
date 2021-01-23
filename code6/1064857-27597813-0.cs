     private void Form3_Load(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
        }
    
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (button1.Text == "&Show")
            {
                button1.Text = "&Hide";
                groupBox1.Visible = true;
            }
            else if (button1.Text == "&Hide")
            {
                button1.Text = "&Show";
                groupBox1.Visible = false;
            }
        }
