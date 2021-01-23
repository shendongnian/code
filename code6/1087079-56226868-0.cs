`
public class CodeAndReason : IHttpActionResult
{
    private readonly HttpStatusCode code;
    private readonly string reason;
    public CodeAndReason(HttpStatusCode code, string reason)
    {
        this.code = code;
        this.reason = reason;
    }
    public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
    {
        var response = new HttpResponseMessage(code)
        {
            ReasonPhrase = reason,
            Content = new StringContent(reason),
        };
        return Task.FromResult(response);
    }
    public static IHttpActionResult NotFound(string reason)
    {
        return new CodeAndReason(HttpStatusCode.NotFound, reason);
    }
    public static IHttpActionResult Conflict(string reason)
    {
        return new CodeAndReason(HttpStatusCode.Conflict, reason);
    }
    public static IHttpActionResult Unauthorized(string reason)
    {
        return new CodeAndReason(HttpStatusCode.Unauthorized, reason);
    }
}
`
Used as:
`
return CodeAndReason.NotFound("Record {blah} not found");
`
