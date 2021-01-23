    public class TestController : ApiController
    {
        public override Task<HttpResponseMessage> ExecuteAsync(HttpControllerContext controllerContext, CancellationToken cancellationToken)
        {
            var featureFlag = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["EnableTest"]);
            if (featureFlag == false)
            {
                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.Gone));
            }
            return base.ExecuteAsync(controllerContext, cancellationToken);
        }
