      var customers = (from c in DbContext.Customers
                       select new
                       {
                           FirstName = c.FirstName,
                           ProjectName = c.Project.Name
    
                       }).ToList().Select(x => new Customer
                       {
                           FirstName = x.FirstName,
                           Project = new Project()
                           {
                               Name = x.ProjectName
                           }
                       }).ToList();
