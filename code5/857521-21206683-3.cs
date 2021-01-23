    [System.Web.Services.WebMethod]
    public static void CallUCMethodFromJQuery(string sAvailability)
    {
        MyNamespace.UserControls.ControlName.EditAvailabilityValue(sAvailability);
    }
