    var colleges = db.Colleges
                     .Select(cld => new OurCollege()
                      {
                          Name = cld.Name,
                          Contact = cld.Contact,
                          MyCourses = (from crs in cld.Course
                                      select new OurCourse
                                      {
                                        Name = crs.Name,
                                        NumberOfYears = crs.Years
                                      }).ToList()    
                       }).ToList();   
