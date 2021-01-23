    students
        .GroupBy(s => new{s.Class, s.Division})
        .Select(g => new StudentCount{Count = g.Count(),
                                      Class = g.Key.Class, 
                                      Divison = g.Key.Division})
