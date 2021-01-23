    var qry = (from c in context.Customers
                           select new CustomerDTO()
                           {
                               FirstName = c.FirstName,
                               Projects = (from pr in context.Projects
                                           where c.ProjectId equals pr.Id
                                           select new ProjectDTO { Name = pr.Name}).ToList()
                           });
