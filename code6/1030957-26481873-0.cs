    var result= (
        from row in dt.AsEnumerable()
        group row by row.Field<string>("NAME") into g
        select new Foo
        {
            Name = g.Key,
            Price=g.Min (x =>x.Field<float>("PRICE")),
            Manufacturer = g.First().Field<string>("MANUFACTURER")
        }
    ).ToList();
