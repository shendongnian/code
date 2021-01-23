    var selectedSubject = context.Students
                             .Include(d => d.Subjects)
                             .Select(dr => new
                                           {
                                               Name = dr.Student.FirstName,
                                               NoOfSubject = dr.Subjects.Count()
                                           })
                             .ToList();
