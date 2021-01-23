    [WebMethod]
    public static void SendDataVoid(string param)
    {
        try
        {
           //do stuff here
        }
        catch (Exception ex)
        {
            System.Web.Services.WebService wsError = new System.Web.Services.WebService();
            wsError.Context.Response.StatusCode = 500;
            wsError.Context.Response.AppendHeader("error", ex.Message);
            
        }
    }
