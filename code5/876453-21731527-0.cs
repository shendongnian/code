    List<string> colsToUpdate = new List<string> { "Column1", "Column2", "..." };
    foreach (DataRow row in table.Rows)
    {
        foreach (String colName in colsToUpdate)
        {
            string oldValue = row.Field<string>(colName);
            if(oldValue.StartsWith("%"))
                row.SetField(colName, "@" + oldValue.Substring(1));
        }
    }
