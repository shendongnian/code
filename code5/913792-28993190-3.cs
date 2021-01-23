    public class AuthenticationFailureResult : IHttpActionResult{
    private object ResponseMessage;
    public AuthenticationFailureResult(string reasonPhrase, HttpRequestMessage request, object responseMessage)
    {
        ReasonPhrase = reasonPhrase;
        Request = request;
        ResponseMessage = responseMessage;
    }
    public string ReasonPhrase { get; private set; }
    public HttpRequestMessage Request { get; private set; }
    public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
    {
        return Task.FromResult(Execute());
    }
    private HttpResponseMessage Execute()
    {
        HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
        System.Net.Http.Formatting.MediaTypeFormatter jsonFormatter = new System.Net.Http.Formatting.JsonMediaTypeFormatter();
        response.Content = new System.Net.Http.ObjectContent<object>(ResponseMessage, jsonFormatter);
        response.RequestMessage = Request;
        response.ReasonPhrase = ReasonPhrase;
        return response;
    }}
