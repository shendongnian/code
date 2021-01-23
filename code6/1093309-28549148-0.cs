    var groupedObjects = from row in dataTable.AsEnumerable()
                     group row by row.Field<string>("Color")
                     into grp
                     select new MyObject
                     {
                        Name = grp.Key,
                        Items = grp.Select(x => new Item 
                                                { 
                                                   Title = x.Field<string>("Title"),
                                                   Color = x.Field<string>("Color"), 
                                                   Value = x.Field<int>("Value")
                                                }).ToList()
                     };
