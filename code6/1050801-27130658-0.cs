    dtMain.AsEnumerable()
      .GroupBy(b => b.Field<string>("Name"))
      .SelectMany(g => g.Select((x,idx) => new
                                {
                                    Name = idx == 0 ? g.Key : "",
                                    Plot = x.Field<int>("Plot"),
                                    Area = x.Field<Decimal>("Area"),
                                }).ToList();
