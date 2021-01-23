    List<string> colArr=new List<string>();
    foreach (DataColumn column in table.Columns)
    {
        colArr.Add(column.ColumnName);
    }
