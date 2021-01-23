    foreach (DataRow row in table1.Rows)
    {
        object[] itemArray = row.ItemArray;
        if (itemArray.Length < 1 || itemArray.All(r => r == null || string.IsNullOrEmpty(r.ToString())))
        {
            table2.ImportRow(row);
        }
    }
