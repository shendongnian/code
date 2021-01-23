    int?[] ranges = new int?[] { 1500, 2500, 4000 };
    var groups = from p in people
                    group p by ranges.FirstOrDefault(r => r > p.Value) into g
                    where g.Key != null
                    select new
                    {
                        From = ranges.Where(x => x < g.Key)
                                     .Select(x => x + 1).DefaultIfEmpty(0).Last(),
                        To = g.Key,
                        People = g
                    };
