    public class MessageHandlerBranding : DelegatingHandler {
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);
            //If we want to forward headers from inner content we can do this:
            if (response.Content != null && response.Content.Headers.Any())
            {
                foreach (var hdr in response.Content.Headers)
                {
                    var keyUpr = hdr.Key.ToUpper(); //Response will not tolerate setting of some header values
                    if ( keyUpr != "CONTENT-TYPE" && keyUpr != "CONTENT-LENGTH")
                    {
                        string val = hdr.Value.Any() ? hdr.Value.FirstOrDefault() : "";
                        response.Headers.Add(hdr.Key, val);                       
                    }
                }
            }
            //Add our branding header to each response
            response.Headers.Add("X-Powered-By", "My product");
            return response;
        }  
    }
