    [System.Web.Services.WebMethod]
    public static string GetCurrentTime(string name)
    {
    return "Hello " + name + Environment.NewLine + "The current time is: "
        + DateTime.Now.ToString();
    }
