    foreach (DataRow row in data.Rows)
    {
        ListViewItem lst = default(ListViewItem);
    
        for (int i = 0; i <= data.Columns.Count - 1; i++)
        {
            if (i == 0)
               lst = new ListViewItem(row[0].ToString());
            else
               lst.SubItems.Add(row[i].ToString());
        }
        lvw.Items.Add(lst);
    }
