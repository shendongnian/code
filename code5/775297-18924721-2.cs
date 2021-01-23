     public List<RoleGridViewModel> GridRoles()
        {
            using (VuittonEntities db = new VuittonEntities())
            {
                return (from users in db.User
                        join roles in db.UserRole on users.RoleID equals roles.RoleID
                        select new RoleGridViewModel
                        {
                            UserID = users.UserID,
                            UserFirst = users.FirstName,
                            UserLast = users.LastName,
                            UserRole = roles.Role,
                            UserRoleDesc = roles.Role_Desc
                        }).ToList();
                        
            }
        }
