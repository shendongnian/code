    var rows = table.AsEnumerable();
    var columns = table.Columns.Cast<DataColumn>();
    int i;  // used to check if a string column can be parsed to int
    DataColumn colToGroup = table.Columns.Cast<DataColumn>()
         .First(c => c.ColumnName.Equals("partnername", StringComparison.OrdinalIgnoreCase));
    var colsToSum = columns
         .Where(c => c != colToGroup &&
             (c.DataType == typeof(int) ||
             (c.DataType == typeof(string)
             && rows.All(r => int.TryParse(r.Field<string>(c), out i)))));
    var columnsToSum = new HashSet<DataColumn>(colsToSum);
    DataTable tblSum = table.Clone(); // empty table, same schema
    foreach (var group in rows.GroupBy(r => r[colToGroup]))
    {
        DataRow row = tblSum.Rows.Add();
        foreach(var col in columns)
        {
            if (columnsToSum.Contains(col))
            {
                int sum;
                if (col.DataType == typeof(int))
                    sum = group.Sum(r => r.Field<int>(col));
                else
                    sum = group.Sum(r => int.Parse(r.Field<string>(col)));
                row.SetField(col.ColumnName, sum);
            }
            else
                row[col.ColumnName] = group.First()[col];
        }
    }
