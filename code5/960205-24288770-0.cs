    var customers = engine.ReadFile(filename)
                          .Cast<*type of the class coming back from ReadFile*>()
                          .Select(c => new MyNamespace.CustomerClass()
                                           {
                                                CustomerId = c.CustomerId,
                                                FirstName = c.FirstName,
                                                LastName = c.LastName
                                           })
                          .ToArray();
