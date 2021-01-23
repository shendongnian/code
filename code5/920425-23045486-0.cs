    public class UsersProvider : RoleProvider
     {
         public override void AddUsersToRoles(string[] username, string[] roleName)
        {
            using (SmaCareEntities db = new SmaCareEntities())
            {
                List<int> ulist = (from u in db.Users
                                   where username.Contains(u.UserName)
                                   select u.RoleId).ToList();
                List<int> rlist = (from r in db.Roles
                                   where roleName.Contains(r.Name)
                                   select r.Id).ToList();
                var urlist = (from r in rlist
                              select new Role { Id = r }).FirstOrDefault();
                db.Roles.Attach(urlist);
                db.ObjectStateManager.ChangeObjectState(urlist, EntityState.Modified);
                db.SaveChanges();
            
            }
        }
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }
        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }
        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            using (SmaCareEntities db = new SmaCareEntities())
            {
                User user = db.Users.FirstOrDefault(u => u.UserName.Equals(usernameToMatch, StringComparison.CurrentCultureIgnoreCase) || u.Email.Equals(usernameToMatch, StringComparison.InvariantCultureIgnoreCase));
                var roles = from r in db.Roles
                            where user.RoleId == r.Id
                            select r.Name;
                if (roles != null)
                    return roles.ToArray();
                else return null;
            }
        }
        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }
        public override string[] GetRolesForUser(string username)
        {
            using (SmaCareEntities db = new SmaCareEntities())
            {
                User user = db.Users.FirstOrDefault(u => u.UserName.Equals(username, StringComparison.CurrentCultureIgnoreCase) || u.Email.Equals(username, StringComparison.InvariantCultureIgnoreCase));
                var roles = user.Role.Name;
                if (roles != null)
                    return new string[] {roles};
                else
                    return new string[] { };
            }
        }
        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }
        public override bool IsUserInRole(string username, string roleName)
        {
            using (SmaCareEntities db = new SmaCareEntities())
            {
                User user = db.Users.FirstOrDefault(u => u.UserName.Equals(username, StringComparison.CurrentCultureIgnoreCase) || u.Email.Equals(username, StringComparison.CurrentCultureIgnoreCase));
                if (user != null)
                {
                    var roles = user.Role.Name;
                    if (user != null)
                        return roles.Equals(roleName, StringComparison.CurrentCultureIgnoreCase);
                    else
                    {
                        return false;
                    }
                }
                else
                    return false;
            }
        }
        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }
        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
