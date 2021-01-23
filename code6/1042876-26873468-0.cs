    public static object[] GetItemArray(this DataRow row, DataRowVersion version)
    {
        var count = (row.Table).Columns.Count;
        var items = new List<object>(count);
        for (var i = 0; i < count; i++)
        {
            items.Add(row[i, version]);
        }
        return items.ToArray();
    }
