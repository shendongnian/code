                var query = from role in roles
                        group role by role.PermissionsInRole
                            into g
                            select new
                            {
                                PinR = g.Key,
                                role = g.ToList()
                            };
            var transferList = (from w in query
                from pr in w.PinR
                select new
                {
                    Feature = pr.Feature, Permission = pr.Permission, TransferRole = w.role.Single()
                })
                .ToList()
                .GroupBy(o => o.Feature, (key, o) =>
                new FeaturesApiModel
                {
                    Name = key.Name,
                    Permissions = o.GroupBy(transferObject => transferObject.Permission, (subKey,transferObject) =>
                        new PermissionsApiModel
                        {
                            PermissionName = subKey.Description,
                            Role = transferObject.Select(flatTransferObject => new RoleAPIModel {Name = flatTransferObject.TransferRole.Name})
                        }
                    )
                });
