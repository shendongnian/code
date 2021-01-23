    public int AddRole(Role role)
    {
        if (!Roles.Any(r => r.RoleName == "VP"))
        {
            Roles.Add(role.RoleName);
            return 0;
        }
        else
        {
            return -101;
        }
    }
