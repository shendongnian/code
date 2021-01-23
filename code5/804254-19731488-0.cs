    public void AddHandlerMapping(string siteName, string name, string executablePath)
    {
        using (ServerManager serverManager = new ServerManager())
        {
            Configuration siteConfig = serverManager.GetApplicationHostConfiguration();
            ConfigurationSection handlersSection = siteConfig.GetSection("system.webServer/handlers", siteName);
            ConfigurationElementCollection handlersCollection = handlersSection.GetCollection();
            bool exists = handlersCollection.Any(configurationElement => configurationElement.Attributes["name"].Value.Equals(name));
            if (!exists)
            {
                ConfigurationElement addElement = handlersCollection.CreateElement("add");
                addElement["name"] = name;
                addElement["path"] = "*";
                addElement["verb"] = "*";
                addElement["modules"] = "IsapiModule";
                addElement["scriptProcessor"] = executablePath;
                addElement["resourceType"] = "Unspecified";
                addElement["requireAccess"] = "None";
                addElement["preCondition"] = "bitness32";
                handlersCollection.Add(addElement);
                serverManager.CommitChanges();
            }
        }
    }
