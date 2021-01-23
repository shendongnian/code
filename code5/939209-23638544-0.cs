    var lstUsers = DBContext.Users.Where(
                        x => x.UserPermissions.Any(
                                        y => y.Suppliers.Any(z => z.UserID == 6)
                                                )
                                        ).ToList();
