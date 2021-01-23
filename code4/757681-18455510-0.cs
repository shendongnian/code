    var list = from ss in studentSubjects
               group ss by s.SubjectName into g
               select new StudentSubjectsCounts
               {
                   Name = g.Key,
                   Count = g.Count(),                           
               };
