     List<StudentDto> objresult = db.Students.Where(c => c.StudentId == 1)
                                    .Select(c => new StudentDto { 
                                           FirstName = c.FirstName, 
                                           LastName = c.LastName, 
                                           Department = c.Department, 
                                           EmailAddress = c.EmailAddress })
                                    .ToList();
     return objresult;
