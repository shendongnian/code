    private void button1_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < checkedListBox1.Items.Count; i++)
        {
            if (checkedListBox1.GetItemChecked(i))
            {
                dataGridView1.Rows.Add(checkedListBox1.Items[i], "1");
            }
        }
    }
