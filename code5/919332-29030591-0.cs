    SPSecurity.RunWithElevatedPrivileges(delegate()
    {
        using (SPSite site = new SPSite(this.Page.Request.Url.ToString()))
        {
            using (SPWeb thisWeb = site.OpenWeb())
            {
                // do something with thisWeb
            }
        }
    });
