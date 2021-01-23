    Projects.Where(w => w.Status.Description == "Not Started").Select(s =>
                            new CustomerProjectDDL()
                            {
                                  ProjectName = new ProjectName()
                                {
                                   ProjectID = s.Project,
                                   Name = s.Name
                                },
    
                                 Customer = new Customer()
                                {
                                    CustomerID = s.CustomerID,
                                    Email = s.Customer.Email,
                                    City = s.Customer.City,
                                    State = s.Customer.State,
                                    Zip = s.Customer.Zip
                                }
    
                            });
