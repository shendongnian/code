    public string[] GetRolesForUser(string userName)
    {
        // Get "standard" roles (User, Admin) ...
        List<string> roles = GetStandardRolesForUser(string userName);
        if (IsUsersCompanyActive(userName))
        {
            roles.Add("LicensedUser");
        }
        return roles.ToArray();
    }
