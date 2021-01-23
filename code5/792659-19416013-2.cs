        private static Site GetSite(string siteName)
        {
            Site site = (from s in (new ServerManager().Sites) where s.Name == siteName select s).FirstOrDefault();
            if (site == null)
                throw new Exception("The Web Site Name \"" + siteName + "\" could not be found in IIS!");
            return site;
        }
        private static ApplicationCollection GetApplications(Site site)
        {
            //HttpContext.Current.Trace.Warn("Site ID3: " + site + "/n");
            
            ApplicationCollection appColl = site.Applications;
            
            return appColl;
        }
        private static String GetHostName(Site site)
        {
            BindingCollection bindings = site.Bindings;
            String bind = null;
            
            foreach (Binding binding in bindings)
                if (binding.Host != null)
                    return binding.ToString();
            
            return bind;
        }
