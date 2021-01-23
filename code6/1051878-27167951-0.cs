    var distinctNames = table.AsEnumerable()
        .Select(row => new
        {
            Name = row.Field<string>("Name"),
            Family = row.Field<string>("Family"),
            ID = row.Field<int>("ID")
        })
        .Distinct();
    var distinctProperties = table.AsEnumerable()
        .Select(row => new
        {
            ID = row.Field<int>("ID"),
            PropertyID = row.Field<int>("PropertyID"),
            PropertyEnergy = row.Field<int>("PropertyEnergy")
        })
        .Distinct();
 
