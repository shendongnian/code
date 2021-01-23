     var StudentsByCourseId = from s in db.Students
                join c in db.Classes on s.ClassId equals c.Id
                join t in db.Teachers on c.TeacherId equals t.Id
                group s by new { s.ClassId, Class = c.Name, Teacher = t.Name } 
                into g
                select new
                {
                  StudentInClass = g.Count(),
                  g.Key.Class,
                  g.Key.Teacher,
                };
