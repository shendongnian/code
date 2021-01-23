    DataTable table = new DataTable();
    List<string> header = new List<string>();
    foreach (DataColumn col in table.Columns)
    {
        if (col.ColumnName.StartsWith("Id")) // you can remove this line if you want to add all of them
           header.Add(col.ColumnName);
    }
