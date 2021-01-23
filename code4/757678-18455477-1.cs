    var list = from s in students
               group s by s.StudentSubjects.Select(ss => ss.SubjectName)
               select new StudentSubjectsCounts
               {
                   Name = g.Key,
                   Count = g.Count(),                           
               };
