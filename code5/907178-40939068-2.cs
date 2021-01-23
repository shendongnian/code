    [RoutePrefix("api/AppUsageReporting")]
    public class AppUsageReportingController : ApiController
        {
        	[HttpGet]
        	// Specify default routing parameters if the parameters aren't specified
        	[Route("UsageAggregationDaily/{userId=}/{startDate=}/{endDate=}")]
        	public async Task<HttpResponseMessage> UsageAggregationDaily(string userId, DateTime? startDate, DateTime? endDate)
        	{
        		if (String.IsNullOrEmpty(userId))
        		{
        			return Request.CreateResponse(HttpStatusCode.BadRequest, $"{nameof(userId)} was not specified.");
        		}
        
        		if (!startDate.HasValue)
        		{
        			return Request.CreateResponse(HttpStatusCode.BadRequest, $"{nameof(startDate)} was not specified.");
        		}
        
        		if (!endDate.HasValue)
        		{
        			return Request.CreateResponse(HttpStatusCode.BadRequest, $"{nameof(endDate)} was not specified.");
        		}
        	}
        }
