    var selectedSubject = context.Students
                             .Include(d => d.Subjects)
                             // .Where() goes here, 
                             .ToList()
                             .Select(dr => new
                                           {
                                               Name = dr.Student.FirstName,
                                               NoOfSubject = dr.Subjects.Count
                                           })
                             .ToList();
