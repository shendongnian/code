    private static string GetBindings()
    {
        // Get the Site name 
        string siteName = System.Web.Hosting.HostingEnvironment.SiteName;
        // Get the sites section from the AppPool.config
        Microsoft.Web.Administration.ConfigurationSection sitesSection =
            Microsoft.Web.Administration.WebConfigurationManager.GetSection(null, null,
                "system.applicationHost/sites");
        foreach (Microsoft.Web.Administration.ConfigurationElement site in sitesSection.GetCollection())
        {
            // Find the right Site
            if (String.Equals((string) site["name"], siteName, StringComparison.OrdinalIgnoreCase))
            {
                // For each binding see if they are http based and return the port and protocol
                foreach (Microsoft.Web.Administration.ConfigurationElement binding in site.GetCollection("bindings")
                    )
                {
                    var bindingInfo = (string) binding["bindingInformation"];
                    if (bindingInfo.IndexOf(".azurewebsites.net", StringComparison.InvariantCultureIgnoreCase) > -1)
                    {
                        return bindingInfo.Split(':')[2];
                    }
                }
            }
        }
        return null;
    }
