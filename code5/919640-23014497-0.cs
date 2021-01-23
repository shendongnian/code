            using (var context = new DBEntities())
            {
                var _stud = (from s in context.Students where s.studID == "001" select s).FirstOrDefault<Student>();
                
                foreach (Course c in _stud.Courses.ToList())
                {
                    _stud.Courses.Remove(c);
                    context.SaveChanges();
                }
            }
