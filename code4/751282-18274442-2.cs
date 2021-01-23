    foreach (var item in query)
    {
        var newRow = target.NewRow();
        // static columns
        newRow["TableName"] = item.Key.TableName;
        newRow["RowId"] = item.Key.Id;
        // dynamic columns
        foreach (var c in item)
        {
            if(!target.Columns.Contains(c.ColumnName))
            {
                target.Columns.Add(new DataColumn(c.ColumnName, typeof(String)));
            }
            newRow[c.ColumnName] = c.ColumnValue;
        }
        target.Rows.Add(newRow);
    }
