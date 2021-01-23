    var baseQuery = context.People;
    
    var joined = type == "A" ?
        baseQuery.Join(PeopleExtendedInfoA,
            p => p.Id,
            a => a.PeopleId,
            (p, a) => new { p, a.Hobby }) :
        baseQuery.Join(PeopleExtendedInfoB,
            p => p.Id,
            b => b.PeopleId,
            (p, b) => new { p, b.Hobby });
    var result = joined.Select(x => new
        {
            x.p.Name,
            x.p.Address,
            // etc.
            x.Hobby
        };
