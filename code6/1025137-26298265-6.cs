    var colleges = db.Colleges
                     .Select(cld => new OurCollege()
                      {
                          Name = cld.Name,
                          Contact = cld.Contact,
                          MyCourses = cld.Course
                                         .Select(crs => new OurCourse()
                                         {
                                             Name = crs.Name,
                                             NumberOfYears = crs.Years
                                         })
                       }).ToList();
