    var xdoc = XDocument.Load(fileName);
    var bills = from b in xdoc.Descendants("BILL")
                group b by (string)b.Element("DATE") into g
                select new {
                    Date = g.Key,
                    TotalPrice = g.Element("LIST")                              
                                  .Elements("PRICE")
                                  .Sum(p => (decimal)p)
                };
