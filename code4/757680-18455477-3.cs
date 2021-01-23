    var list = from s in students
               group s by s.StudentSubjects.Select(ss => ss.SubjectName) into g
               select new StudentSubjectsCounts
               {
                   Name = g.Key,
                   Count = g.Count(),                           
               };
