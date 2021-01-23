    public class OrderInformationResponse
    {
        public GetOrderLookupResponseType orderLookupResponse { get; set; }
    }
    
    [System.Web.Services.WebMethod]
    public static void GetOrderInformation(string jobId, string userId, string jobDetails)
    {
        OrderInformationResponse response = new OrderInformationResponse();
        JobDetails jobDetailsEnum = (JobDetails)Enum.Parse(typeof(JobDetails), jobDetails);
        response.orderLookupResponse = GetOrderLookup(jobId, userId);
        string json = JsonConvert.SerializeObject(response); //I use Json.NET, but use whatever you want
        HttpContext.Current.Response.ContentType = "application/json";
        HttpContext.Current.Response.Write(json);
    }
