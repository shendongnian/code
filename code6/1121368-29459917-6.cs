    var qry = (from c in context.Customers
                           select new CustomerDTO()
                           {
                               CustomerId = c.CustomerId,
                               Projects = (from pr in context.Projects
                                           where c.ProjectId equals pr.Id
                                           select new ProjectDTO
                                           { 
                                                Description = pr.Description,
                                                Quote = pr.Quote
                                           }).ToList()
                           });
