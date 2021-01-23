    while (listView1.SelectedItems.Count > 0) 
    {
       if (listView1.SelectedItems.Count == 1)
       {
           ListViewItem item = listView1.SelectedItems[0];
           textBox1.Text = item.Text;
           numericUpDown1.Value = Convert.ToDecimal(item.SubItems[1]);
           comboBox1.Text = item.SubItems[2].Text;
           textBox3.Text = item.SubItems[3].Text;
       }
       listView1.Items.Remove(listView1.SelectedItems[0]);
    }   
