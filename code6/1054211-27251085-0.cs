     var result = (from users in userService.GetListSimple()
                                 .Where(d => d.RegisterTime >= new DateTime(2013, 01, 01) 
                                        && d.RegisterTime <= new DateTime(2013, 01, 10,23,59,59))
                   group users by new {
                              Date = EntityFunctions.TruncateTime(users.RegisterTime), 
                              Name = users.partners.Name, 
                              PartnerId = users.partners.PartnerId } into gr
                                  select new
                                  {
                                      gr.Key.Date,
                                      gr.Key.Name,
                                      gr.Key.PartnerId,
                                      Ammount = gr.Count()
                                  }
                    ).OrderBy(d => d.Date);
