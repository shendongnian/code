    DataTable Datatable3 = dt1.AsEnumerable().Union(dt2.AsEnumerable())
                                                .GroupBy(x => x.Field<int>("Id"))
                                                .Select(x =>
                                                    {
                                                        var topWeightItem = x.OrderByDescending(z => z.Field<int>("Weight")).First();
                                                        return new Items
                                                            {
                                                                Id = x.Key,
                                                                Name = topWeightItem.Field<string>("Name"),
                                                                Weight = topWeightItem.Field<int>("Weight"),
                                                                DataTable1 = dt1.AsEnumerable().Any(z => z.Field<int>("Id") == x.Key && z.Field<int>("Weight") ==
                                                                                                            topWeightItem.Field<int>("Weight")
                                                                                                            && z.Field<string>("Name") ==
                                                                                                              topWeightItem.Field<string>("Name")) ? "X" : String.Empty,
                                                                DataTable2 = dt2.AsEnumerable().Any(z => z.Field<int>("Id") == x.Key && z.Field<int>("Weight") ==
                                                                                                            topWeightItem.Field<int>("Weight")
                                                                                                            && z.Field<string>("Name") ==
                                                                                                              topWeightItem.Field<string>("Name")) ? "X" : String.Empty
                                                            };
                                                    }
                                                    ).PropertiesToDataTable<Items>();
