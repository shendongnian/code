    List<Order> orders = xdoc.Descendants("order")
                        .Select(x => new Order
                        {
                          OrderNumber = (string)x.Element("ordernumber"),
                          Items = x.Descendants("item")
                                   .Select(i => new Item
                                   {
                                      Name = (string)i.Element("name") }).ToList()
                                   }).ToList();
