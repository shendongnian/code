    var typed = invalidDataList
                     .GroupBy(d => d.Type)
                     .Select(g => new
                         {
                             Type = g.Key,
                             Data = g.Select(d => d.Data).ToList()
                         })
                     .ToList();
    var table =  new DataTable();
    foreach(var type In typed)
    {
        table.Columns.Add(type.Type);
    }
    var maxCount = typed.Max(t => t.Data.Count);
    for(var i = 0; i < maxCount; i++)
    {
        var row = table.NewRow();
        foreach(var type in typed)
        {
            if (type.Data.Count > i)
            {
                row[type.Type] = type.Data[i]
            }
        }
        table.Rows.Add(row);
    }
