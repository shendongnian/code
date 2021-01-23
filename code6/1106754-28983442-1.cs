    var users = dt.AsEnumerable()
                  .GroupBy(r => new 
                     {
                       Id = r["Id"], 
                       Name=r["UserName"], 
                       Password = r["Password"]
                     })
                  .Select(g => new User() 
                     {
                       Id = (Guid)g.Key.Id, 
                       Name = g.Key.Name as string, 
                       Password = g.Key.Password as string, 
                       Roles = g.Select(r => new Role() 
                                  {
                                    Id = (int)r["RoleId"],
                                    Name = r["RoleName"] as string
                                  })
                              /*.Distinct()*/
                                .ToList()
                     })
                  .ToList();
