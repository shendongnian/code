            string webSiteName = "Default Web Site";
            string applicationName = "MyApp";
            using (ServerManager server = new ServerManager())
            {
                ConfigurationSection config = server.GetApplicationHostConfiguration().GetSection("system.webServer/security/authentication/anonymousAuthentication", webSiteName + "/" + applicationName);
                config.OverrideMode = OverrideMode.Allow;
                config["enabled"] = true;
                server.CommitChanges();
            }
