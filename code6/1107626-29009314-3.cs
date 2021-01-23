    List<string> columnNames = new List<string> { "Name", "Gender" };
    var columnsToGroupBy = table.Columns.Cast<DataColumn>()
        .Where(c => columnNames.Contains(c.ColumnName, StringComparer.InvariantCultureIgnoreCase))
        .ToArray();
    var comparer = new MultiFieldComparer();
    var summed = table.AsEnumerable()
        .GroupBy(row => columnsToGroupBy.Select(c => row[c]), comparer)
        .Select(group => new
        {
            AllFields = group.Key,
            Sum = group.Sum(row => row.IsNull("Age") ? 0 : decimal.Parse(row["Age"].ToString()))
        });
    foreach (var x in summed)
    {
        Console.WriteLine("{0} Sum: {1}", string.Join(" ", x.AllFields), x.Sum);
    }
