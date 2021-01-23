    [HttpGet]
    [Route("AggregationTotal/{userId=}")]
    public async Task<HttpResponseMessage> AggregationTotal(string userId)
    {
          if (String.IsNullOrEmpty(userId))
          {
              return Request.CreateResponse(HttpStatusCode.BadRequest, $"{nameof(userId)} was not specified.");
          }
    }
