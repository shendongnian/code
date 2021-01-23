    using (var trans = session.BeginTransaction())
                {
                    var ali = new Employee { FirstName = "fname", LastName = "lname"};
                   var stor = new Store { Id = "1", Name= "Firststore"}; // for creating new store 
                   AddEmployees(stor,emp);
                    session.SaveOrUpdate(ali);
                    session.SaveOrUpdate(stor);
                    trans.Commit();
                }
               Public void AddEmployees(Store str, Employee emp)
               {
                  str.add_employee(emp);
               }
