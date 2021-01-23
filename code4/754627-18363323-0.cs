    protected void UpdateUsers()
    {
        Configuration config = (Configuration)WebConfigurationManager.OpenWebConfiguration("~");
        AuthorizationSection root_section = (AuthorizationSection)config.GetSection("system.web/authorization");
    
        //Remove all Current Users in root location.
        root_section.Rules.Clear();
    
        //Add Deny All Users to root location.
        AuthorizationRule rootDeny = new AuthorizationRule(AuthorizationRuleAction.Deny);
        rootDeny.Users.Add("*");
        root_section.Rules.Add(rootDeny);
    
        //Add New Users to root location.
        AuthorizationRule rootAuth = new AuthorizationRule(AuthorizationRuleAction.Allow);
        rootAuth.Users.Add("domain\\rootusername1");
        rootAuth.Users.Add("domain\\rootusername2");
    
        root_section.Rules.Add(rootAuth);
        root_section.CurrentConfiguration.Save();
    
        ConfigurationLocationCollection section = config.Locations;
        foreach (ConfigurationLocation location in section)
        {
            if(location.Path == "Admin")
            {
                Configuration adminConfig = (Configuration)location.OpenConfiguration();
                AuthorizationSection admin_section = (AuthorizationSection)adminConfig.GetSection("system.web/authorization");
    
                //Remove all Current Users in admin location.
                admin_section.Rules.Clear();
    
                //Add Deny All Users to root location.
                AuthorizationRule adminDeny = new AuthorizationRule(AuthorizationRuleAction.Deny);
                adminDeny.Users.Add("*");
                admin_section.Rules.Add(adminDeny);
    
                //Add New Users to admin location.
                AuthorizationRule adminAuth = new AuthorizationRule(AuthorizationRuleAction.Allow) ;
                adminAuth.Users.Add("domain\\adminusername1");
                adminAuth.Users.Add("domain\\adminusername2");
    
                admin_section.Rules.Add(adminAuth);
                //admin_section.CurrentConfiguration.Save();
            }
    
        }
    }
