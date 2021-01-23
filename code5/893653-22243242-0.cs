    Uri OrganizationUri = new Uri("http://crm/XRMServices/2011/Organization.svc");
    Uri HomeRealmUri = null;
   
    using (OrganizationServiceProxy serviceProxy = new OrganizationServiceProxy(OrganizationUri, HomeRealmUri, Credentials, null))
    {
                      
        IOrganizationService service = (IOrganizationService)serviceProxy;
        if (Context.User.Identity.IsAuthenticated)
           {
             string EUserName = Context.User.Identity.Name;
              string WinUserName = WindowsIdentity.GetCurrent().Name;
              UserName.InnerText = EUserName;
           }
    }
    Also add references
    **microsoft.crm.sdk.proxy**
    **microsoft.xrm.sdk**
