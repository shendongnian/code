     var query1 = from s in context.Archive
                             //join us in context.Users
                             //on s.Salesman.ID equals us.ID
                              group s by new    // group by multiple columns
                              {
                                s.Salesman.Id,
                                s.first_name,
                                 s.surname,
                              } into g                     
                            orderby g.Sum(o => o.Price) descending
                            select new
                           {
                            Salesman_ID = g.Key,
                            FirstName = g.first_name,
                            Surname = g.surname,
                            Sale = g.Sum(o => o.Price),
                        };
