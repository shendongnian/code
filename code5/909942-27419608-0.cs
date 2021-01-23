    [HttpGet]
    public HttpResponseMessage DoSomething([FromUri] string ValtoProcess)
    {
        try
        {
           return ControllerContext.Request.CreateResponse(HttpStatusCode.OK, new { result, message });
        }
        catch(exception ex)
        {
           HttpResponseMessage Response =Request.CreateErrorResponse(HttpStatusCode.InternalServerError,ex.InnerException.Message);
                throw new HttpResponseException(Response);
         }
