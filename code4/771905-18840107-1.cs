    var list3 = list1.AsEnumerable()
                     .GroupBy(x=>x.Field<string>("facility"))
                     .Select(g=> new Facility{ Facility=g.Key,       
                                 Services = g.GroupBy(x=>x.Field<string>("Role"))
                                             .Select(g1=> new Service{
                                                        Service = g1.Key,
                                                        Roles = g1.GroupBy(x=>x.Field<string>("RWP"))
                                                                  .Select(g2=> new Role{
                                                                      H = g2.Key
                                                                   }).ToList()
                                                     }).ToList()
                            }).ToList();    
