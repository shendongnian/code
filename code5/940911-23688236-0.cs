    IEnumerable<string> strings = new List<string>() { "blah", "blah blah", "blah blah blah" };
    DataTable table = new DataTable();
    table.Columns.Add(
        new DataColumn()
        {
            DataType = Type.GetType("System.String"),
            ColumnName = "String"
        });
    DataRow row;
    foreach (string aString in strings)
    {
        row = table.NewRow();
        row["String"] = aString;
        table.Rows.Add(row);
    }
