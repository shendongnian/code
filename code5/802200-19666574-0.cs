    try
    {
        //Load the empty base configuration file
        Configuration config = WebConfigurationManager.OpenWebConfiguration("~/WebEmpty.config");
        //Get te authorization section
        AuthorizationSection sec = config.GetSection("system.web/authorization") as AuthorizationSection;
        //Create the access rules that you want to add
        AuthorizationRule allowRule = new AuthorizationRule(AuthorizationRuleAction.Allow);
        allowRule.Users.Add("userName");
        //allowRule.Users.Add("userName2"); Here can be added as much users as needed
        AuthorizationRule denyRule = new AuthorizationRule(AuthorizationRuleAction.Deny);
        denyRule.Users.Add("*");
        //Add the rules to the section
        sec.Rules.Add(allowRule);
        sec.Rules.Add(denyRule);
        //Save the modified config file in the created folder
        string path = MapPath("~/NewFolder/Web.config");
        config.SaveAs(path);
    }
    catch (Exception ex)
    {
        //Handle the exceptions that could appear
    }
