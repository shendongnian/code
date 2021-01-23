    var result = (from x in xdoc.Root.Elements()
                  select new Order
                  {
                      OrderNumber = (string)x.Element("ordernumber"),
                      Items = x.Element("items")
                               .Elements("item")
                               .Select(itemElement =>
                                   new Item { Name = itemElement.Value })
                               .ToList()
                  }).ToList();
