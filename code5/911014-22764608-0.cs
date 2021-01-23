      public class NullJsonHandler : DelegatingHandler
        {
            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
     
                var response = await base.SendAsync(request, cancellationToken);
                if (response.Content == null)
                {
                    response.Content = new StringContent("{}");
                } else if (response.Content is ObjectContent)
                {
                    var objectContent = (ObjectContent) response.Content;
                    if (objectContent.Value == null)
                    {
                        response.Content = new StringContent("{}");
                    }
                    
                }
                return response;
            }
        }
