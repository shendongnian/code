        private void button1_Click(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem();
            item.Text = textBox1.Text + "\t" + dateTimePicker1.Text;
            if (comboBox1.SelectedIndex == 0)
            {                              
                item.ForeColor = Color.Red;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                item.ForeColor = Color.Blue;                
            }
            listView1.Items.Add(item);
        }
