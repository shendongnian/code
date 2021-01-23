    private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = (Form1)this.Owner;
            int i = 0;
            ListViewItem item = form1.listView1.SelectedItems[i];
            item.SubItems[0].Text = textBox1.Text;
            item.SubItems[1].Text = richTextBox1.Text;
            item.SubItems[2].Text = comboBox1.Text;
            item.SubItems[3].Text = dateTimePicker1.Text;
            this.Close();
        }
