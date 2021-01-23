    string accountName = @"DOMAIN\user";
    var groupNames = new[] { "DOMAIN\Domain Users", "DOMAIN\Group2" }; // the groups that we need to verify if the user is member of
    // cannot create WindowsIdentity because it requires username in form user@domain.com but the passed value will be DOMAIN\user.
    using (var pc = new PrincipalContext(System.DirectoryServices.AccountManagement.ContextType.Domain, Environment.UserDomainName))
    {
        using (var p = UserPrincipal.FindByIdentity(pc, accountName))
        {
            // if the account does not exist or is not an user account
            if (p == null)
                return new string[0];
            // if you need just the UPN of the user, you can use this
            ////return p.UserPrincipalName;
            // find all groups the user is member of (the check is recursive).
            // Guid != null check is intended to remove all built-in objects that are not really AD gorups.
            // the Sid.Translate method gets the DOMAIN\Group name format.
            var userIsMemberOf = p.GetAuthorizationGroups().Where(o => o.Guid != null).Select(o => o.Sid.Translate(typeof(NTAccount)).ToString());
            // use a HashSet to find the group the user is member of.
            var groups = new HashSet<string>(userIsMemberOf, StringComparer.OrdinalIgnoreCase);
            groups.IntersectWith(groupNames);
            return groups;
        }
    }
