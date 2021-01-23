            var allRoles = roles.Table
                .AsEnumerable().Select(p => new FirmRole
                {
                    Code = p.Field<string>("RoleName"),
                    Name = p.Field<string>("RoleName")
                }).GroupBy(x => x.StartsWith("f")).ToLookup(g2 => g2.Key);;
            var formRoles = allRoles[true].ToList();
            var otherRoles = allRoles[false].ToList();
