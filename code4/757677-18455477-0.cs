    var list = from s in students
               group s by s.StudentSubjects
               select new StudentSubjectsCounts
               {
                   Name = g.Key.SubjectName,
                   Count = g.Count(),                           
               };
