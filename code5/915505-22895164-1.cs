    private void button1_Click(object sender, EventArgs e)
            {
    
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        string str = (string)checkedListBox1.Items[i];
                        if(str ==  "rtb1")
                        {
                          richTextBox1.Clear();
                          richTextBox1.Focus();
                        }
                         if(str ==  "rtb2")
                        {
                           richTextBox2.Clear();
                           richTextBox2.Focus();
                        }
                    }
                }
