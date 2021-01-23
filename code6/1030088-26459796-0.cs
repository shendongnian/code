    var result = session
        .Query<TableXy>()
        // instead of this
        //.Where(x => NHibernate.Linq.SqlMethods.Like(x.Source, "%\\_aa"))
        // This will add sign % at the beginning only
        .Where(x => x.Source.EndsWith("[_]aa"));
        // or wrap it on both sides with sign: % 
        .Where(x => x.Source.Contains("[_]aa"));
        .ToList();
