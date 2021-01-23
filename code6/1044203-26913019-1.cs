    var sorted = new XDocument(
                    new XElement(
                       "employees",
                       ORIGINAL_XDOC.Descendants("employee")
                                    .OrderBy(e => e.Descendants("lastName")
                                                   .Single()
                                                   .Value)
                                    .ThenBy(e => e.Descendants("firstName")
                                                  .Single()
                                                  .Value)));
