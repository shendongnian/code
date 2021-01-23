    var query = table.AsEnumerable()
        .GroupBy(row => new { Name = row.Field<string>("Name"), Code = row.Field<string>("Code") });
    var table2 = table.Clone(); // empty table with same schema
    foreach (var x in query)
    {
        string name = x.Key.Name;
        string code = x.Key.Code;
        int count = x.Sum(r => r.Field<int>("Count"));
        table2.Rows.Add(x.Key.Name, x.Key.Code, count);
    }
