    students
        .GroupBy(s => new{s.Class, s.Division})
        .Select(g => new StudentCount{Count = g.Count(),
                                      g.Key.Class, 
                                      g.Key.Division})
