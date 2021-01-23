    var child1 = new List<IDictionary<string, object>>
    {
        new Dictionary<string, object> { { "ChildName", "John" }, { "ChildAge", 10 } }
    };
    var child2 = new List<IDictionary<string, object>>
    {
        new Dictionary<string, object> { { "ChildName", "Tony" }, { "ChildAge", 12 } }
    };
    var parent = new List<IDictionary<string, object>>
    {
        new Dictionary<string, object> 
        { 
            { "Name", "Mike" },
            { "LastName", "Tyson" },
            { "child1", child1 },
            { "child2", child2 }
        },
        new Dictionary<string, object>
        {
            { "Name", "Lykke" },
            { "LastName", "Li" },
            { "child1", child1 },
        },
        new Dictionary<string, object>
        { 
            { "Name", "Mike" },
            { "LastName", "Oldfield" }
        }
    };
    CreateTable(parent);
    static DataTable CreateTable(IEnumerable<IDictionary<string, object>> parents)
    {
        var table = new DataTable();
        foreach (var parent in parents)
        {
            var children = parent.Values
                                 .OfType<IEnumerable<IDictionary<string, object>>>()
                                 .ToArray();
            var length = children.Length == 0 ? 1 : children.Length;
            var childEntries = children.SelectMany(x => x.First())
                                       .ToLookup(x => x.Key, x => x.Value);
            var parentEntries = parent.Where(x => x.Value is string)
                                      .ToArray()
                                      .Repeat(length)
                                      .ToLookup(x => x.Key, x => x.Value);
            var allEntries = parentEntries.Concat(childEntries)
                                          .ToDictionary(x => x.Key, x => x.ToArray());
            var headers = allEntries.Select(x => x.Key)
                                    .Except(table.Columns.Cast<DataColumn>().Select(x => x.ColumnName))
                                    .Select(x => new DataColumn(x))
                                    .ToArray();
            table.Columns.AddRange(headers);
            var addedRows = new Tuple<int, int>[length];
            for (int i = 0; i < length; i++)
                addedRows[i] = Tuple.Create(table.Rows.IndexOf(table.Rows.Add()), i);
            foreach (DataColumn col in table.Columns)
            {
                object[] columnRows;
                if (!allEntries.TryGetValue(col.ColumnName, out columnRows))
                    continue;
                foreach (var row in addedRows)
                    table.Rows[row.Item1][col] = columnRows[row.Item2];
            }
        }
        return table;
    }
