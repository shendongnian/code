    from r in table.AsEnumerable()
    group r by r.Field<string>("Lead Owners") into g
    select new {
       LeadOwners = g.Key,
       2Days = g.Sum(r => r.Field<int?>("2Days")),
       5Days = g.Sum(r => r.Field<int?>("5Days"))
       // etc
    }
