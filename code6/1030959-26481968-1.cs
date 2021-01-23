    var result= (
      from row in dt.AsEnumerable()
      group row by new 
      { 
        row.Field<string>("NAME"), 
        row.Field<string>("MANUFACTURER") 
      }  into g
      select new Foo
      {
        Name = g.Key.Name,
        Manufacturer = g.Key.Manufacturer,
        Price=g.Min (x =>x.Field<float>("PRICE"))
      }
    ).ToList();
