    [System.Web.Services.WebMethod]
    public static void CallUCMethodFromJQuery(string sAvailability)
    {
        MyNamespace.UserControls.ControlName m = new UserControls.ControlName();
        m.EditAvailabilityValue(sAvailability);
    }
