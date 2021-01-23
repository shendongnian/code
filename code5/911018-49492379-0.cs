    public class NullJsonHandler : DelegatingHandler
        {
            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
    
                var updatedResponse = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = null
                };
    
                var response = await base.SendAsync(request, cancellationToken);
    
                if (response.Content == null)
                {
                    response.Content = new StringContent("{}");
                }
    
                else if (response.Content is ObjectContent)
                {
          
                    var contents = await response.Content.ReadAsStringAsync();
    
                    if (contents.Contains("null"))
                    {
                        contents = contents.Replace("null", "{}");
                    }
    
                    updatedResponse.Content = new StringContent(contents,Encoding.UTF8,"application/json");
      
                }
    
                var tsc = new TaskCompletionSource<HttpResponseMessage>();
                tsc.SetResult(updatedResponse);   
                return await tsc.Task;
            }
        }
