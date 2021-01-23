    var list3 = list1.GroupBy(x=>x.facility)
                     .Select(g=> new Facility{ Facility=g.Key,       
                                 Services = g.GroupBy(x=>x.Role)
                                             .Select(g1=> new Service{
                                                        Service = g1.Key,
                                                        Roles = g1.GroupBy(x=>x.RWP)
                                                                  .Select(g2=> new Role{
                                                                      H = g2.RWP
                                                                   }).ToList()
                                                     }).ToList()
                            }).ToList();    
