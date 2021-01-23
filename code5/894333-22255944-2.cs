        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.CheckedItems = string.Empty;
            foreach (var item in checkedListBox1.CheckedItems)
            {
                Properties.Settings.Default.CheckedItems += item + "," ;
            }
            Properties.Settings.Default.Save();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Properties.Settings.Default.CheckedItems);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            var checkedItems = Properties.Settings.Default.CheckedItems.ToString().Split(',');
            foreach (var item in checkedItems)
            {
                var index=checkedListBox1.FindString(item);
                if(index>=0)
                {
                    checkedListBox1.SetItemChecked(index, true);
                }
            }
        }
