    var sortedUsers =
         yourRootXElement.Element("users")
                         .Elements()
                         .Select(usr => 
                                   new {
                                         managerId = usr.Element("manager")
                                                        .Element("dn")
                                                        .Value, 
                                         user = usr
                                        }) 
                         .OrderBy(user => user.managerId);
