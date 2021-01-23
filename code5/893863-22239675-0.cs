    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace Tigra.Gravatar.LogFetcher.Specifications
        {
        /// <summary>
        ///   Class LoggingHttpMessageHandler.
        ///   Provides a fake HttpMessageHandler that can be injected into HttpClient.
        ///   The class requires a ready-made response message to be passed in the constructor,
        ///   which is simply returned when requested. Additionally, the web request is logged in the
        ///   RequestMessage property for later examination.
        /// </summary>
        public class LoggingHttpMessageHandler : DelegatingHandler
            {
            internal HttpResponseMessage ResponseMessage { get; private set; }
            internal HttpRequestMessage RequestMessage { get; private set; }
    
            public LoggingHttpMessageHandler(HttpResponseMessage responseMessage)
                {
                ResponseMessage = responseMessage;
                }
    
            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                CancellationToken cancellationToken)
                {
                RequestMessage = request;
                return Task.FromResult(ResponseMessage);
                }
            }
        }
