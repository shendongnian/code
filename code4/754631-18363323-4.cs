    protected void UpdateUsers()
    {
        Configuration config = (Configuration)WebConfigurationManager.OpenWebConfiguration("~");
        AuthorizationSection root_section = (AuthorizationSection)config.GetSection("system.web/authorization");
    
        //Remove all Current Users to root location.
        root_section.Rules.Clear();
    
        //Add New Users to root location.
        AuthorizationRule rootAuth = new AuthorizationRule(AuthorizationRuleAction.Allow);
        rootAuth.Users.Add("domain\\rootusername1");
        rootAuth.Users.Add("domain\\rootusername2");
        rootAuth.Users.Add("domain\\rootusername3"); 
        root_section.Rules.Add(rootAuth);
    
        ////Add Deny All Users to root location.
        AuthorizationRule rootDeny = new AuthorizationRule(AuthorizationRuleAction.Deny);
        rootDeny.Users.Add("*");
        root_section.Rules.Add(rootDeny);
    
        root_section.CurrentConfiguration.Save();
        
        //Other Locations  
        ConfigurationLocationCollection section = config.Locations;
    
        foreach (ConfigurationLocation location in section)
        {
            if (location.Path == "admin") //This is case Sensitive
            {
                Configuration adminConfig = (Configuration)location.OpenConfiguration();
                AuthorizationSection admin_section = (AuthorizationSection)adminConfig.GetSection("system.web/authorization");
    
                //Remove all Current Users to admin location.
                admin_section.Rules.Clear();
    
                ////Add New Users to admin location.
                AuthorizationRule adminAuth = new AuthorizationRule(AuthorizationRuleAction.Allow);
                adminAuth.Users.Add("domain\\adminusername1");
                adminAuth.Users.Add("domain\\adminusername2");
                adminAuth.Users.Add("domain\\adminusername3");
                adminAuth.Users.Add("domain\\adminusername4");
                admin_section.Rules.Add(adminAuth);
                adminAuth = null;
    
                ////Add Deny All Users to root location.
                AuthorizationRule adminDeny = new AuthorizationRule(AuthorizationRuleAction.Deny);
                adminDeny.Users.Add("?"); // For some reason if I remove this line it says "Object reference not set to an instance of an object"
                adminDeny.Users.Add("*");
                admin_section.Rules.Add(adminDeny);
    
                admin_section.CurrentConfiguration.Save();
            }
    
        }
    }
