    for (int i = 0; i < gridView1.VisibleRowCount; i++)
    {
        DataRow row = gridView1.GetDataRow(i);
        string name = row["ColumnName"].ToString();
    }
