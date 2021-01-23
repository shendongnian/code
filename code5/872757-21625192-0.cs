    //on the local machine use this
    string domainName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
    //on the publishing server use this
    string domainName = System.Web.HttpContext.Current.User.Identity.Name
    string name = domainName.Substring(domainName.LastIndexOf("\\") + 1);
