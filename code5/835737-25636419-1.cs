    private void Form1_Load(object sender,EventArgs e)
        {
            checkedListBox1.Items.Add("IIT");
            checkedListBox1.Items.Add("CSE");
            checkedListBox1.Items.Add("EEE");
            checkedListBox1.Items.Add("ICT");
            checkedListBox1.Items.Add("URP");
            checkedListBox1.Items.Add("ENGLISH");
            checkedListBox1.Items.Add("BANGLA");
            checkedListBox1.Items.Add("MATH");
        }
        private void checkedListBox1_SelectedIndexChanged(object sender,EventArgs e)
        {
            //var item=checkedListBox1.SelectedItem;
            label1.Text=checkedListBox1.SelectedItem.ToString();
        }
