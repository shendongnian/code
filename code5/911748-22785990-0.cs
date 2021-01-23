    var result =
        defaults.GroupJoin(
            get,
            p1 => p1.PermissionName,
            p2 => p2.PermissionName,
            (p1, joined) =>
                new
                {
                    PermissionName = p1.PermissionName,
                    Permission = joined.Select(e => e.Permission != null)
                                       .SingleOrDefault()
                });
