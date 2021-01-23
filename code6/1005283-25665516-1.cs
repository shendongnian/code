    public static string GetCurrentApplicationPoolName()
        {
            ServerManager manager = new ServerManager();
            string DefaultSiteName = System.Web.Hosting.HostingEnvironment.ApplicationHost.GetSiteName();
            Site defaultSite = manager.Sites[DefaultSiteName];
            string appVirtualPath = HttpRuntime.AppDomainAppVirtualPath;
            
            string appPoolName = string.Empty;
            foreach (Application app in defaultSite.Applications)
            {
                string appPath = app.Path;
                if (appPath == appVirtualPath)
                {
                    appPoolName = app.ApplicationPoolName;
                }   
            }
            return appPoolName;
        }
