    [WebMethod,ScriptMethod(...params if need...)]
    public static string getDataByDate(string days)
    {
        DataSet ds = new DataSet();
        ds = getPatientVisitCount(DateTime.Today.ToString(), DateTime.Today.ToString()));
        return ds.GetXml();
    }
