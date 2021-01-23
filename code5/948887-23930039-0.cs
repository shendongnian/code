    protected Role GetRole()
    {
        var role = Session["Role"] as Role;
        if (role == null)
        {
            role = new Role();
            Session["Role"] = role;
        }
        return role;
    }
