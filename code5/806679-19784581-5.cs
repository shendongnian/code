    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static object getDataByDate(string days)
    {
        DataSet ds = new DataSet();
        ds = getPatientVisitCount(DateTime.Today.ToString(), DateTime.Today.ToString()));
        string json = Newtonsoft.Json.JsonConvert.SerializeXmlNode(ds.GetXml());
        return json;
    }
