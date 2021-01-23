    if (!(Roles.Provider is CustomRoleProvider))
    {
        var rolesType = typeof (Roles);
        var flags = BindingFlags.Static | BindingFlags.NonPublic;
        var provider = _container.Resolve<CustomRoleProvider>();
        rolesType.GetField("s_Provider", flags).SetValue(null, provider);
        var providers = new RoleProviderCollection();
        providers.Add(provider);
        rolesType.GetField("s_Providers", flags).SetValue(null, providers);
    }
