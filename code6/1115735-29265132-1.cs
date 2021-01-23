    ctx.Courses.Join(ctx.CourseDepartments,
                     c => c.ID, cd => cd.cID,
                     (c, cd) => new {
                         Course = c,
                         dID = cd.dID
                     }).Join(ctx.Departments,
                             c => c.dID,
                             d => d.ID,
                             (c, d) => new {
                                   Course = c.Course,
                                   Department = d
                     });
