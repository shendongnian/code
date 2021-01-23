    var Users = _db.Users
                .Where(u => _db.UserPermissions
                    .Select(x => UserID)
                    .Distinct()
                    .Where(x => _db.UserPermissions
                        .Where(y => y.UserID == 6)
                        .Select(y => y.SupplierID)
                        .Contains(x))
                    );
