    public class HttpRetryMessageHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> sendAsync = base.SendAsync;
    
            return await Policy
                .Handle<HttpServerErrorException>()
                .WaitAndRetry(5, retryCount => TimeSpan.FromSeconds(Math.Pow(3, retryCount)))
                .ExecuteAsync(
                    async () =>
                    {
                        var responseMessage = await sendAsync(request, cancellationToken).ConfigureAwait(false);
    
                        var code = (int)responseMessage.StatusCode;
                        if ((code >= 500) && (code < 600))
                        {
                            throw new HttpServerErrorException(
                                $"HTTP response indicates server error. StatusCode:<{code}>");
                        }
    
                        return responseMessage;
                    });
        }
    }
    [Serializable]
    public class HttpServerErrorException : Exception
    {
        public HttpServerErrorException()
        {
        }
    
        public HttpServerErrorException(string message) : base(message)
        {
        }
    
        public HttpServerErrorException(string message, Exception inner) : base(message, inner)
        {
        }
    
        protected HttpServerErrorException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
