    public class NotAcceptableConnegHandler : DelegatingHandler
    {
        private const string allMediaTypesRange = "*/*";
     
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var acceptHeader = request.Headers.Accept;
            if (!acceptHeader.Any(x => x.MediaType == allMediaTypesRange))
            {
                var hasFormetterForRequestedMediaType = GlobalConfiguration
                    .Configuration
                    .Formatters
                    .Any(formatter => acceptHeader.Any(mediaType => formatter.SupportedMediaTypes.Contains(mediaType)));
     
                if (!hasFormetterForRequestedMediaType)
                    return Task<HttpResponseMessage>.Factory.StartNew(() => new HttpResponseMessage(HttpStatusCode.NotAcceptable));
            }
            return base.SendAsync(request, cancellationToken);
        }
    }
