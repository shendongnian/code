    var result= (
      from row in dt.AsEnumerable()
      group row by row.Field<string>("NAME") into g
      let x = new
      {
        Name = g.Key.Name,
        Price=g.Min (x =>x.Field<float>("PRICE"))
      }
      where (row.Name == x.Name && row.Price == x.Price)
      select new Foo
      {
        Name = row.Name,
        Manufacturer = row.Manufacturer,
        Price= row.Price
      }
    ).ToList();
