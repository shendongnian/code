    [System.Web.Services.WebMethod]
    public static void Carica(int ID)
    {
        List<CustomObject> elenco = new List<CustomObject>();
        try
        {
            elenco = GetElencoByID(ID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        Response.ContentType = "application/json";
        Response.Write(JsonConvert.SerializeObject(elenco)); //using JSON.NET, but any serializer should do
        Response.End();
    }
