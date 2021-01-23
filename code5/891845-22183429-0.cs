    void listView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (listView1.SelectedIndices.Contains(0))
        {
            listView2.Items.Clear();
            listView2.Items.AddRange(groceries.Select(g => new ListViewItem(g)).ToArray());
        }
    }
