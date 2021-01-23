    var query = rankedList.Join(        // outer collection
                    AllMovieInfo,       // inner collection
                    r => r.MovieID,     // outer key selector
                    a => a.MovieID,     // inner key selector
                    (r, a) => new       // result selector
                    {
                        Info = a, Rank = r.count
                    }).AsEnumerable()
                      .OrderByDescending(o => o.Rank)
                      .Distinct();
