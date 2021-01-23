    [System.Web.Services.WebMethod]
    public static string GetData(string name)
    {
        WCF_Web_Service.Service1 client = new WCF_Web_Service.Service1();
        string Name=client.GetData(name);
        return Name;
    }
