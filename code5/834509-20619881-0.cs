    public override string[] GetRolesForUser(string username)
        {
            List<string> allRoles = new List<string>();
            var ctx = new PrincipalContext(ContextType.Domain);
            UserPrincipal user = UserPrincipal.FindByIdentity(ctx, username);
            if (user != null)
            {
                var groups = user.GetGroups();
                allRoles.AddRange(groups.Select(x => x.Name));
            }
    
            return allRoles.ToArray();
        }
