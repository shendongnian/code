    var ids = studentWithAge.Select(s => s.Id)
        .Union(studentWithSexAndComplexion.Select(s => s.Id));
    var query =
        from id in ids
        join sa in studentWithAge on id equals sa.Id into sas
        join ssc in studentWithSexAndComplexion on id equals ssc.Id into sscs
        from sa in sas.DefaultIfEmpty(new ObjectItem { Id = id })
        from ssc in sscs.DefaultIfEmpty(new ObjectItem { Id = id })
        select new ObjectItem
        {
            Id = id,
            Name = sa.Name ?? ssc.Name,
            Sex = ssc.Sex,
            Age = sa.Age,
            Complexion = ssc.Complexion,
        };
