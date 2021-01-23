    [System.Web.Http.Route("{id:guid}")]
    public class MyApiController: ApiController
    {
        public HttpResponseMessage Get(Guid id)
        {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
