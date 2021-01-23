    var ageSumsPerNameAndGender = table.AsEnumerable()
        .GroupBy(row => new { Name = row.Field<string>("Name"), Gender = row.Field<string>("Gender") })
        .Select(group => new
        {
            Name = group.Key.Name,
            Gender = group.Key.Gender,
            SumOfAge = group.Sum(row => row.Field<int>("Age"))
        });
