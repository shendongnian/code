    session.QueryOver<PersonEntity>()
        .Select(
            Projections.Max(
                ProjectionExtensions.SplitPart<Person>(p => p.FullName, "-", 2)))
        .SingleOrDefault<int>();
