    var q =
        dt.AsEnumerable()
            .AsQueryable()
            .GroupBy("new(it[\"Field1\"] as Field1,it[\"Field2\"]as Field2)", "it")
            .Select("new(Key as Group, Sum(double(it[\"NR\"])) as Tot)");
    foreach (var v in q)
    {
        Console.WriteLine(v);
    }
