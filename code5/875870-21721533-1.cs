    public class ResultWithChallenge : IHttpActionResult
    {
        private readonly IHttpActionResult next;
    
        public ResultWithChallenge(IHttpActionResult next)
        {
            this.next = next;
        }
    
        public async Task<HttpResponseMessage> ExecuteAsync(
                                    CancellationToken cancellationToken)
        {
            var response = await next.ExecuteAsync(cancellationToken);
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                response.Headers.WwwAuthenticate.Add(
                       new AuthenticationHeaderValue("Basic", "realm=localhost"));
            }
    
            return response;
        }
    }
