    var ownerGroups = dt.AsEnumerable()
        .GroupBy(row => row.Field<string>("Lead Owners"));
    var dt2 = dt.Clone();
    var intColumns = dt2.Columns.Cast<DataColumn>()
        .Where(c => c.DataType == typeof(int)).ToArray();
    foreach (var grp in ownerGroups)
    {
        var row = dt2.Rows.Add();
        row.SetField("Lead Owners", grp.Key);
        foreach (DataColumn col in intColumns)
        {
            bool anyNonNull = grp.Any(r => r.Field<int?>(col.Ordinal).HasValue);
            int? sum = anyNonNull ? grp.Sum(r => r.Field<int?>(col.Ordinal)) : null;
            row.SetField(col, sum);
        }
    }
