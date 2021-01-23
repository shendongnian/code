    public class MyMessageHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(
                HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var myTempObj = new { id = 20 };
            if (request.Properties.ContainsKey("MS_QueryNameValuePairs"))
            {
                var items = (Dictionary<string,string>)request.Properties["MS_QueryNameValuePairs"];
                items.Add("UserId", myTempObj.id.ToString());
            }
            else
            {
                if (!string.IsNullOrEmpty(request.RequestUri.Query) && request.RequestUri.Query.Contains('?'))
                {
                    request.RequestUri = new Uri(request.RequestUri + "&UserID=" + myTempObj.id);
                }
                else
                {
                    request.RequestUri = new Uri(request.RequestUri + "?UserID=" + myTempObj.id);
                }    
            }
            return base.SendAsync(request, cancellationToken);
        }
    }
 
