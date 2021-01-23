    DataTable dt = new DataTable {
        Columns = {
            "Click", "Impression", "Cost", "Click-past",
            "Impression-past", "cost-past"
        }
    };
    Dictionary<string, DataColumn> colByName = dt.Columns.OfType<DataColumn>()
        .ToDictionary(x => x.ColumnName, StringComparer.InvariantCultureIgnoreCase);
    List<DataColumn> sorted = new List<DataColumn>(dt.Columns.Count);
    foreach (DataColumn col in dt.Columns)
    {
        if (!col.ColumnName.EndsWith("-past",
            StringComparison.InvariantCultureIgnoreCase))
        {
            sorted.Add(col);
            DataColumn past;
            if (colByName.TryGetValue(col.ColumnName + "-past", out past))
                sorted.Add(past);
        }
    }
    int ordinal = 0;
    foreach(var col in sorted)
    {
        col.SetOrdinal(ordinal++);
    }
    foreach(DataColumn col in dt.Columns)
        System.Console.WriteLine(col.ColumnName);
