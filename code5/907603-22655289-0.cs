    string[]ar=new string[dt.Columns.Count];
    for (int i = 0; i < dt.Rows.Count; i++)
    {
    	for (int c=0;c <dt.Columns.Count; c++)
    	    ar[c] = dt.Rows[i][c].ToString();
    	
    	listView1.Items.Add(new ListViewItem(ar));
    }
