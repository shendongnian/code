    `using System.Security.Principal;
    protected void YourOperation()
    {
        // Obtain the authenticated user's Identity and impersonate the original caller
        using (((WindowsIdentity)HttpContext.Current.User.Identity).Impersonate())
        {
            WCFTestService.ServiceClient myService = new WCFTestService.ServiceClient();
            Response.Write(myService.GetData(123) + "<br/>");
            myService.Close();
        }
    }`
