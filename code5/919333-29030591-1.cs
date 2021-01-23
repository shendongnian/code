    private void yourFunction()
    {
          SPSite site = SPContext.Current.Site;
          SPWeb web = SPContext.Current.Web;
          SPSecurity.RunWithElevatedPrivileges(delegate()
          {
                using (SPSite ElevatedSite = new SPSite(site.ID))
                {
                      using (SPWeb ElevatedWeb = ElevatedSite.OpenWeb(web.ID))
                      {
                            // Code Using the SPWeb Object Goes Here
                      }
                }
           });
    }
