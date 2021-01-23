    List<DataRow> rows = new List<DataRow>();
    foreach (DataRow row in table.Rows)
        rows.Add(row);
    var result = rows.GroupBy(r => r["className"])
                     .Select(g => new
                     {
                         className = g.Key,
                         division = g.GroupBy(r => r["Division"])
                                     .Select(g1 => new
                                     {
                                         name = g1.Key,
                                         subject = g1.Select(r => new
                                                     {
                                                         name = r["Subject"]
                                                     })
                                     })
                     });
    string json = JsonConvert.SerializeObject(result, Formatting.Indented);
    Console.WriteLine(json);
