    static DataTable CreateTable(IEnumerable<IDictionary<string, object>> parents)
    {
        var table = new DataTable();
        //excuse the meaningless variable names
        var c = parents.FirstOrDefault(x => x.Values
                                             .OfType<IEnumerable<IDictionary<string, object>>>()
                                             .Any());
        var p = c ?? parents.FirstOrDefault();
        if (p == null)
            return table;
        var headers = p.Where(x => x.Value is string)
                       .Select(x => x.Key)
                       .Concat(c == null ? 
                               Enumerable.Empty<string>() : 
                               c.Values
                                .OfType<IEnumerable<IDictionary<string, object>>>()
                                .First()
                                .SelectMany(x => x.Keys))
                       .Select(x => new DataColumn(x))
                       .ToArray();
        table.Columns.AddRange(headers);
        foreach (var parent in parents)
        {
            var children = parent.Values
                                 .OfType<IEnumerable<IDictionary<string, object>>>()
                                 .ToArray();
                
            var length = children.Any() ? children.Length : 1;
            var parentEntries = parent.Where(x => x.Value is string)
                                      .Repeat(length)
                                      .ToLookup(x => x.Key, x => x.Value);
            var childEntries = children.SelectMany(x => x.First())
                                       .ToLookup(x => x.Key, x => x.Value);
            var allEntries = parentEntries.Concat(childEntries)
                                          .ToDictionary(x => x.Key, x => x.ToArray());
            var addedRows = Enumerable.Range(0, length)
                                      .Select(x => new
                                      {
                                          relativeIndex = x,
                                          actualIndex = table.Rows.IndexOf(table.Rows.Add())
                                      })
                                      .ToArray();
            foreach (DataColumn col in table.Columns)
            {
                object[] columnRows;
                if (!allEntries.TryGetValue(col.ColumnName, out columnRows))
                    continue;
                foreach (var row in addedRows)
                    table.Rows[row.actualIndex][col] = columnRows[row.relativeIndex];
            }
        }
        return table;
    }
