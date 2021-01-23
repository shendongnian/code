    var parents = (from p in dt.AsEnumerable()
                        group p by p.Field<int>("parent_id")
                        into g
                        select new Parent
                        {
                            ParentId = g.Key,
                            Children =
                                (from c in g
                                    group c by c.Field<int>("child_id")
                                    into childGroup
                                    select new Child
                                    {
                                        ChildId = childGroup.Key,
                                        Books = childGroup.Select(c => c.Field<string>("books")).ToList()
                                    }).ToList()
                        }).ToList();
