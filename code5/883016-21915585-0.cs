     public class Myhandler: DelegatingHandler
     {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessagerequest,   CancellationToken cancellationToken)
        { 
            if(request.Headers.Contains("accountid") && request.Headers.Contains("apikey")) 
            {
                 
                string accountid = request.Headers.GetValues("accountid").FirstOrDefault();
                string apikey = request.Headers.GetValues("apikey").FirstOrDefault();
                  
                    //HERE you can get your account and do what you want
            }else{
                  return SendError("please provide account id and api key", HttpStatusCode.Forbidden);
            }
               return base.SendAsync(request, cancellationToken);
        }
        private Task<HttpResponseMessage> SendError(string error, HttpStatusCode code)
        {
            var response = new HttpResponseMessage();
            response.Content = new StringContent(error);
            response.StatusCode = code;
            return Task<HttpResponseMessage>.Factory.StartNew(() => response);
        }
    }
