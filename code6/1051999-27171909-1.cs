    var lstUser = doc.Descendants("Users").Descendants("User")
        .Select(dem => new User
        {
            UserId = dem.Element("USRID").Value,
            UserName = dem.Element("USERNAME").Value,
            UserRoles = dem.Descendants("ROLES").Descendants("ROLE")
                .Select(x => new Role
                {
                    RoleId = x.Element("ROLEID").Value,
                    RoleName = x.Element("ROLENAME").Value,
                    IsDefaultRole = x.Element("ISDEFAULTROLE").Value == "1"
                })
               .ToList()
        }).ToList();
