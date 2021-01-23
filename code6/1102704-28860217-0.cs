    public List<AgencyData> Get(String state, String city)
    {
        //var queryValues = Request.RequestUri.ParseQueryString();
        //string filter = queryValues.Get("filter").ToString();
        List<AgencyData> json;
        json = SQLAllAgencyData("");
        return json;
    }
