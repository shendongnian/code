      public string currentRole(UserViewModel uvm)
        {            
            using (VuittonEntities db = new VuittonEntities())
            {
                return (from us in db.User
                        join usRole in db.UserRole on us.RoleID equals usRole.RoleID
                        where (us.RoleID == uvm.RoleID) && (us.UserID == uvm.UserID)
                        select usRole.Role).First();
            }
        }   
