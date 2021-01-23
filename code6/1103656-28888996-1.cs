    public abstract class BaseApiController : ApiController 
    {
            protected HttpResponseMessage HandleResponse(BaseResponse response)
            {
                return
                    !response.IsSuccess
                        ? Request.CreateErrorResponse(HttpStatusCode.BadRequest, response.Errors )
                        : Request.CreateResponse(HttpStatusCode.OK, response);
            }
    }
