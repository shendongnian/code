    public class SimpleController : IHttpController
    {
        public async Task<HttpResponseMessage> ExecuteAsync(HttpControllerContext controllerContext, CancellationToken cancellationToken)
        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                RequestMessage = controllerContext.Request,
                Content = new StringContent("Hello World")
            };
        }
    }
 
