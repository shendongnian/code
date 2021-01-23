    var list = students.SelectMany(s => s.StudentSubjects)
                       .GroupBy(ss => ss.SubjectName)
                       .Select(g => new StudentSubjectsCounts
                           {
                               Name = g.Key,
                               Count = g.Count(),                           
                           });
