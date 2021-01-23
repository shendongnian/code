     private void button1_Click(object sender, EventArgs e)
            {
                if (checkedListBox1.SelectedItem.ToString() == "rtb1")
                {
                    richTextBox1.Clear();
                    richTextBox1.Focus();
                }
                if (checkedListBox1.SelectedItem.ToString() == "rtb2")
                {
                    richTextBox2.Clear();
                    richTextBox2.Focus();
                }
            }
