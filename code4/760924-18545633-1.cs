        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            string item = textBox1.Text;
            if (textBox1.Text.Length >= 1)
            {
                if (e.KeyCode == Keys.Enter)//If Enter key is pressed while textbox is focused.
                {
                    listBox1.Items.Add(item);
                }
            }
        }
