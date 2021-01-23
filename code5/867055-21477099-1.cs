    [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "/GetProductionDay/{shiftDate}")]
    public int GetProductionDay (string shiftDate) 
    {
        DateTime? dt = DateTimeExtensions.FromUnixTimestamp(shiftDate);  
        ....
        return res;
    }
