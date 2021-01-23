     public class MyMessageHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(
                HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var myTempObj = new {id = 20 };
            if (request.GetQueryNameValuePairs().Count() > 0)
            {
                request.RequestUri = new Uri(request.RequestUri + "&UserID=" + myTempObj.id);
            }
            else
            {
                request.RequestUri = new Uri(request.RequestUri + "?UserID=" + myTempObj.id);
            }
            return base.SendAsync(request, cancellationToken);
        }
    } 
 
