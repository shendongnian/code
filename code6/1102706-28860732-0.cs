    [Route("Agency/{state?}/{city?}")
    public List<AgencyData> Get(string state = null, string city = null)
    {
        List<AgencyData> json;
        json = SQLAllAgencyData("");
        return json;
    }
