    var query = dt.AsEnumerable().GroupBy(x => x.Field<string>("ParentName"))
                                 .Select(x => new Parent
                                        {
                                            Name = x.Key,
                                            Child = x.Select(z => new Children
                                            {
                                                ChildID = z.Field<string>("ChildId"),
                                                Name = z.Field<string>("ChildName")
                                            }).ToList()
                                        });
