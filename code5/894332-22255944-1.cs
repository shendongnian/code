        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.CheckedItems = string.Empty;
            foreach (var item in checkedListBox1.CheckedItems)
            {
                Properties.Settings.Default.CheckedItems += item; ;
            }
            Properties.Settings.Default.Save();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Properties.Settings.Default.CheckedItems);
        }
