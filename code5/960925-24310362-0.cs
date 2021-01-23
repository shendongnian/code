    var query = 
        exams.GroupBy(x => x.DateTime)
             .Select(g => new {
                                  Date = g.Key, 
                                  TotalMarks = g.Sum(s => s.Mark)
                              }
                    );
