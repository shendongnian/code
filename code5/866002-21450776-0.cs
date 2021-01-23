    private void button1_Click(object sender, EventArgs e)
    {
        foreach (ListViewItem item in listView1.Items)
        {
            if (item.Checked)
            {
                dataGridView1.Rows.Add(item.Text, "1");
            }
        }
    }
