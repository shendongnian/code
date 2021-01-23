    void Session_Start(object sender, EventArgs e) 
    {
        string myself = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        string me = User.Identity.Name;
        Response.Write("myself:" + myself + "<br>me:" + me);
    }
