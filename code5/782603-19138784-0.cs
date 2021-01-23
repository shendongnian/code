    var heckOfAnObject = dataTable
                .AsEnumerable()
                .GroupBy(m => m.Field<string>("ParentId"))
                .ToDictionary(
                    a => a.Key,
                    a => a.GroupBy(c => c.Field<string>("Id"))
                          .ToDictionary(
                              d => d.Key,
                              d => d.GroupBy(f => f.Field<string>("Key"))
                                    .ToDictionary(
                                        g => g.Key,
                                        //you'll have to pick one of the value in the grouped values
                                        g => g.First().Field<string>("Value"))));
