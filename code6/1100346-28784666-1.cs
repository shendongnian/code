    var ids = studentWithAge.Select(s => s.Id)
        .Union(studentWithSexAndComplexion.Select(s => s.Id));
    var query =
        from id in ids
        from sa in studentWithAge
                        .Where(sa => sa.Id == id)
                        .DefaultIfEmpty(new ObjectItem { Id = id })
        from ssc in studentWithSexAndComplexion
                        .Where(ssc => ssc.Id == id)
                        .DefaultIfEmpty(new ObjectItem { Id = id })
        select new ObjectItem
        {
            Id = id,
            Name = sa.Name ?? ssc.Name,
            Sex = ssc.Sex,
            Age = sa.Age,
            Complexion = ssc.Complexion,
        };
