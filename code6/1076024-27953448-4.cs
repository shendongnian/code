    IEnumerable<Student> distinctStudents = students
                                               .AsEnumerable()
                                               .GroupBy(s => Tuple.Create
                                                                   (
                                                                       s.studentname, 
                                                                       s.subject, 
                                                                       s.grade
                                                                   )
                                                              )
							                   .Select(g => g.First()); /// Returns the first student of each group
