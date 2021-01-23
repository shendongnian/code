    public static string GetApplicationPoolNames()
        {
            ServerManager manager = new ServerManager();
            string DefaultSiteName = System.Web.Hosting.HostingEnvironment.ApplicationHost.GetSiteName();
            Site defaultSite = manager.Sites[DefaultSiteName];
            string appVirtaulPath = HttpRuntime.AppDomainAppVirtualPath;
            
            string appPoolName = string.Empty;
            foreach (Application app in defaultSite.Applications)
            {
                string appPath = app.Path;
                if (appPath == appVirtaulPath)
                {
                    appPoolName = app.ApplicationPoolName;
                }   
            }
            return appPoolName;
        }
