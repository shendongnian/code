    private void button1_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(groupBox1.Text))
        {
            lst2.Items.AddRange(lst1.SelectedItems);
        }
     }
