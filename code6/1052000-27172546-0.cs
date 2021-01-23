    List<User> users = xdoc.Root.Descendants("User")
                           .Select(x => new User
                                    {
                                       UserId = x.Element("USRID").Value,
                                       UserName = x.Element("USERNAME").Value,
                                       UserRoles = x.Descendants("ROLE")
                                                    .Select(z => new Role
                                                             {
                                                                RoleId = z.Element("ROLEID").Value,
                                                                RoleName = z.Element("ROLENAME").Value,
                                                                IsDefaultRole = z.Element("ISDEFAULTROLE").Value == "1" ? true : false
                                                       }).ToList()
                                   }).ToList();
