    var query = from i in document.Descendants("response")
                           select new MyClass
                           (
                               (string)i.Element("some").Element("property"),
                               (string)i.Element("another").Element("property")
                           )
                           {
                               ResultSet1 = new List<Result>
                                      {
                                          new Result { YetAnotherProperty = ... },
                                          new Result { ... }            
                                      },
                               ResultSet 2 = ...
                           };
