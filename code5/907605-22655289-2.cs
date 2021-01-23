    ListViewItem li = 0;
    for (int i = 0; i < dt.Rows.Count; i++)
    {
    	li = listView1.Items.Add(dt.Rows[i][0].ToString());
    	for (int c = 1; c < dt.Columns.Count; c++)
    		li.SubItems.Add(dt.Rows[i][c].ToString());
    }
