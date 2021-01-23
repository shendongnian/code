    private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;
            using (Form3 form3 = new Form3())
            {
                int i = 0;
                ListViewItem item = listView1.SelectedItems[i];
                string title = item.SubItems[0].Text;
                string description = item.SubItems[1].Text;
                string priority = item.SubItems[2].Text;
                string datedue = item.SubItems[3].Text;
                form3.textBox1.Text = title.ToString();
                form3.richTextBox1.Text = description.ToString();
                form3.comboBox1.Text = priority.ToString();
                form3.dateTimePicker1.Text = datedue.ToString();
                form3.ShowDialog(this);
            }
        }
