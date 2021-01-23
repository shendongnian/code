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
        }
    };
    CreateTable(parent);
    static DataTable CreateTable(IEnumerable<IDictionary<string, object>> parent)
    {            
        var childEntries = parent.First()
                                 .Values.OfType<IEnumerable<IDictionary<string, object>>>()
                                 .SelectMany(x => x.First())
                                 .ToLookup(x => x.Key, x => x.Value);
        int length = childEntries.Max(x => x.Count());
        var parentEntries = parent.First()
                                  .Where(x => x.Value is string)
                                  .ToArray()
                                  .Repeat(length)
                                  .ToLookup(x => x.Key, x => x.Value);
        var allEntries = parentEntries.Concat(childEntries).ToDictionary(x => x.Key);
        var table = new DataTable();
        var headers = allEntries.Select(x => new DataColumn(x.Key)).ToArray();
        table.Columns.AddRange(headers);
        for (int i = 0; i < length; i++)
        {
            table.Rows.Add();
        }
        foreach (DataColumn col in table.Columns)
        {
            var rows = allEntries[col.ColumnName].ToArray();
            for (int i = 0; i < length; i++)
            {
                table.Rows[i][col] = rows[i];
            }
        }
        return table;
    }
