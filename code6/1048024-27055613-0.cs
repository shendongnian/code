    foreach(DataColumn thiscol in ds.Tables[0].Columns)
    {
        lvItems.Columns.Add(thiscol.ColumnName, 60, HorizontalAlignment.Left);
    }
    foreach(DataRow thisrow in ds.Tables[0].Rows)
    {
        string[] fields = new string[thisrow.ItemArray.Length];
        for(int iCount = 0; iCount < fields.Length; iCount++)
        {
            fields[iCount] = thisrow[iCount].ToString();
        }
        lvItems.Items.Add(new ListViewItem(fields));
    }
