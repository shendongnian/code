    public class RequestHandlerWithLastResponse : IDirectWebRequestHandler
        {
        private readonly UntrustedWebRequestHandler _webRequestHandler;
        public string LastResponseContent { get; private set; }
        public RequestHandlerWithLastResponse(UntrustedWebRequestHandler webRequestHandler)
            {
            if (webRequestHandler == null) throw new ArgumentNullException( "webRequestHandler" );
            _webRequestHandler = webRequestHandler;
            }
        public bool CanSupport( DirectWebRequestOptions options )
            {
            return _webRequestHandler.CanSupport( options );
            }
        public Stream GetRequestStream( HttpWebRequest request )
            {
            return _webRequestHandler.GetRequestStream( request, DirectWebRequestOptions.None );
            }
        public Stream GetRequestStream( HttpWebRequest request, DirectWebRequestOptions options )
            {
            return _webRequestHandler.GetRequestStream( request, options );
            }
        public IncomingWebResponse GetResponse( HttpWebRequest request )
            {
            var response = _webRequestHandler.GetResponse( request, DirectWebRequestOptions.None );
            //here we actually getting the response content
            this.LastResponseContent = GetResponseContent( response );
            return response;
            }
        public IncomingWebResponse GetResponse( HttpWebRequest request, DirectWebRequestOptions options )
            {
            return _webRequestHandler.GetResponse( request, options );
            }
        private string GetResponseContent(IncomingWebResponse response)
            {
            MemoryStream stream = new MemoryStream();
            response.ResponseStream.CopyTo(stream);
            stream.Position = 0;
            response.ResponseStream.Position = 0;
            
            using (var sr = new StreamReader(stream))
                {
                return sr.ReadToEnd();
                }
            }
        }
