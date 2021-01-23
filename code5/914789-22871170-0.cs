    public async Task<IList<string>> GetRolesAsync(User user) {
        List<string> roles = new List<string>();
        //Active Directory Roles
        if (user.Email.Contains("@mycompany")) {
            var directory = new CompanyDirectory();
            var adGroups = directory.GetGroupsByUser(user.Email);
            if (adGroups != null && adGroups.Count > 0) {
                roles.AddRange(adGroups);
            }
        }
        //SQL Server Roles
        var dbRoles = await _context.Users
            .Where(u => u.UserName == user.UserName)
            .SelectMany(u => u.Roles)
            .Select(r => r.Name)
            .ToListAsync();
        roles.AddRange(dbRoles);
        return roles;
    }
