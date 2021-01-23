    public ListItemCollection GetAllWebApplicationsInSPFarm()
    {
    ddlDataSource = new ListItemCollection();
    SPSecurity.RunWithElevatedPrivileges(delegate()
    {
    SPServiceCollection services = SPFarm.Local.Services;
    foreach (SPService curService in services)
    {
    if (curService is SPWebService)
    {
    webService = (SPWebService)curService;
    if (curService.TypeName.Equals("Microsoft SharePoint Foundation Web Application"))
    {
    webService = (SPWebService)curService;
    SPWebApplicationCollection webApplications = webService.WebApplications;
    foreach (SPWebApplication webApplication in webApplications)
    {
    if (webApplication != null)
    {
    //Now you have the required object i.e. webApplication. You can use it like this:
    //string webApp = webApplication.AlternateUrls[0].Collection.Name.ToString();
    //Write your code here…    
    }
    }
    }
    }
    }
    });
    }
