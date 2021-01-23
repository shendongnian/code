	public class ContentTypeFilter : DelegatingHandler
    {
        private readonly List<MediaTypeHeaderValue> _suport;
        /// <summary />
        public ContentTypeFilter()
        {
            _suport = new List<MediaTypeHeaderValue>();
            foreach (var formatter in GlobalConfiguration.Configuration.Formatters.ToArray())
            {
                _suport.AddRange(formatter.SupportedMediaTypes);
            }
        }
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var metodos = new List<string> { "POST", "PUT", "PATCH" };
            if (request.Content != null)
            {
                if (metodos.Contains(request.Method.Method.ToUpperInvariant()))
                {
                    MediaTypeHeaderValue contentType = request.Content.Headers.ContentType;
                    // Nas configurações não possui o Charset aceito.
                    if (contentType == null || !_suport.Any(x => x.MediaType.Equals(contentType.MediaType)))
                    {
                        return Task<HttpResponseMessage>.Factory.StartNew(() => CreateResponse(request, "Suported ontent-types: " + string.Join(", ", _suport.Select(x => x.ToString()))));
                    }
                }
            }
            return base.SendAsync(request, cancellationToken);
        }
        private static HttpResponseMessage CreateResponse(HttpRequestMessage request, string mensagem)
        {
            var response = request.CreateResponse(HttpStatusCode.UnsupportedMediaType);
            response.ReasonPhrase = mensagem;
            response.Content = new StringContent(mensagem);
            return response;
        }
    }
