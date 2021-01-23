    var items = new List<Item>
                    {
                        new Item
                            {
                                prop_a = "A", prop_b = "Apple", sort_order = 1
                            }, new Item
                                   {
                                       prop_a = "B", prop_b = "Bat", sort_order = 2
                                   }, new Item
                                          {
                                              prop_a = "C", prop_b = "Crane", sort_order = 3
                                          },
                    };
    var list1 = items.Select(x => new List<string> {x.prop_a, x.prop_b}).ToList();
    var list2 = items.OrderBy(x => x.sort_order).Select(x => new List<string> {x.prop_a, x.prop_b}).ToList();
