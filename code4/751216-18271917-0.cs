    [System.Web.Services.WebMethod]
    publicstaticstring GetCurrentTime(string name)
    {
    return"Hello " + name + Environment.NewLine + "The Current Time is: "
        + DateTime.Now.ToString();
    }
