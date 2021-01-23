    public string[] LookupRolesForUser(string username)
    {
        using (MyContext db = new MyContext())
        {
            var user = db.Users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.CurrentCultureIgnoreCase) || u.Email.Equals(username, StringComparison.CurrentCultureIgnoreCase));
            var roles = from ur in user.Roles
                        from r in db.Roles
                        where ur.RoleId == r.RoleId
                        select r.RoleName;
            if (roles != null)
                return roles.ToArray();
            else
                return new string[] { }; ;
        }
    }
