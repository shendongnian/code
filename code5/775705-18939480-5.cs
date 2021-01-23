    var query = (from r in rankedList
                join a in AllMovieInfo on r.MovieID equals a.MovieID
                select new { Info = a, Rank = r.count })
                .AsEnumerable()
                .OrderByDescending(o => o.Rank);
                .Select(o => o.Info)
                .Distinct(); // will likely need an IEqualityComparer here
    // this could be combined with the above query, but I split it for clarity
    AllMovieInfo = query.AsQueryable();
