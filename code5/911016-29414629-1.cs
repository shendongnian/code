    public class OkJsonPatchResult : OkResult
    {
        readonly MediaTypeWithQualityHeaderValue acceptJson = new MediaTypeWithQualityHeaderValue("application/json");
        public OkJsonPatchResult(HttpRequestMessage request) : base(request) { }
        public OkJsonPatchResult(ApiController controller) : base(controller) { }
        public override Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var accept = Request.Headers.Accept;
            var jsonFormat = accept.Any(h => h.Equals(acceptJson));
            if (jsonFormat)
            {
                return Task.FromResult(ExecuteResult());
            }
            else
            {
                return base.ExecuteAsync(cancellationToken);
            }
        }
        public HttpResponseMessage ExecuteResult()
        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new JsonContent("{}"),
                RequestMessage = Request
            };
        }
    }
