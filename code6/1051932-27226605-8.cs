      public class MyMessageHandler : DelegatingHandler
      {
        protected override Task<HttpResponseMessage> SendAsync(
                HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var myTempObj = new { id = 20 };
          /* You have to check this and remove this key. If key present that FromUri use cached properties*/
            if (request.Properties.ContainsKey("MS_QueryNameValuePairs"))
            {
                request.Properties.Remove("MS_QueryNameValuePairs");                
            }
            
            // Now prepare or update uri over here. It will surely work now.
                if (!string.IsNullOrEmpty(request.RequestUri.Query) && request.RequestUri.Query.Contains('?'))
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
 
