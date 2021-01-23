    var baseQuery = context.People;
    
    var joined = type == "A" ?
        baseQuery.Join(PeopleExtendedInfoA,
            p => p.Id,
            a => a.PeopleId,
            (p, a) => new { p.Name, a.Hobby }) :
        baseQuery.Join(PeopleExtendedInfoB,
            p => p.Id,
            b => b.PeopleId,
            (p, b) => new { p.Name, b.Hobby });
