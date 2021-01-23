    public class ResponseDataFilterHandler : DelegatingHandler
    {
        protected override System.Threading.Tasks.Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return base.SendAsync(request, cancellationToken)
                .ContinueWith(task =>
                {
                    var response = task.Result;
                    var content = response.Content as ObjectContent;
                    if (content != null && content.Value != null)
                    {
                        var isJson = response.RequestMessage.GetQueryNameValuePairs().Any(r => r.Key == "json" && r.Value == "true");
                        response.Content = new StringContent(Helper.GetResponseData(content.Value, isJson));
                    }
                    return response;
                });
        }
    }
