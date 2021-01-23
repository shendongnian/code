    List<MyType> copyMovies = myMovies.Select (m => new MyType()
    {
        Movie = new List<MySubType>(m.Movie),
        Ranks = m.Ranks,
        Location = m.Location,
        Released = m.Released
    }).ToList();
