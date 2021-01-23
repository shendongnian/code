    from r in table.AsEnumerable()
    let id = r.Field<int>("ProductId")
    group r by id into g
    select new {
       ProductId = id,
       CountThisWeek = g.Sum(r => r.Field<int>("CountThisWeek")),
       CountLastWeek = g.Sum(r => r.Field<int>("CountLastWeek"))
    }
