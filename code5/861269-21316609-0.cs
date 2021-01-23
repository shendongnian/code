    var filteredList = list.Select(element => 
                                       new MyClass  {
                                                     // set necessary properties like
                                                      Name = element.Name,
                                                      ...
                                                     }).ToList();
