    [WebMethod]
    public static void GetPreviousSaltsAndHashes(string name)
    {
        List<string> prevSalts= //blah blah, retrieve data
        HttpContext.Current.Response.ContentType="application/json";
        HttpContext.Current.Response.Write(JsonConvert.SerializeObject(prevSalts));
    }
