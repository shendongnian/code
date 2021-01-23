    var nameCodeCountLookup = table.AsEnumerable()
        .GroupBy(row => new { Name = row.Field<string>("Name"), Code = row.Field<string>("Code") })
        .ToDictionary(ncGrp => ncGrp.Key, ncGrp => ncGrp.Sum(r => r.Field<int>("Count")));
    foreach (DataRow row in table.Rows)
    {
        string Name = row.Field<string>("Name");
        string Code = row.Field<string>("Code");
        row.SetField("Count", nameCodeCountLookup[new { Name, Code }]);
    }
