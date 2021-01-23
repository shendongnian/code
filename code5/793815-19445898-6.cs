    var sortedUsers =
        yourRootXElement.Element("users")
                        .Elements()
                        .Select(usr => 
                                    new {
                                        userId =  usr.Element("dn").Value,
                                        managerId = usr.Element("manager")
                                                       .Element("dn")
                                                       .Value,
                                        depth = usr.Element("depth")
                                                   .Value,
                                        userData = usr
                                    })
                        .OrderBy(user => user.depth)
                        .ThenBy(user => user.managerId);
