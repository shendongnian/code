    var query = table.AsEnumerable()
        .GroupBy(row => row.Field<string>("Name"))
        .SelectMany(nameGroup => nameGroup
            .GroupBy(row => row.Field<string>("Code"))
            .Select(codeGroup =>  new
                {
                    Name = nameGroup.Key,
                    Code = codeGroup.Key,
                    Count = codeGroup.Sum(r => r.Field<int>("count"))
                }));
    var table2 = table.Clone(); // empty table with same schema
    foreach (var x in query)
        table2.Rows.Add(x.Name, x.Code, x.Count);
