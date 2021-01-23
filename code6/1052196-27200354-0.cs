    public class RequestAndResponseLoggerDelegatingHandler : DelegatingHandler
    {
        public IDataAccess Data { get; set; }
    
        protected override async Task<HttpResponseMessage> SendAsync(
                                HttpRequestMessage request, 
                                     CancellationToken cancellationToken)
        {
            var started = DateTime.UtcNow;
            var requestContent = await request.Content.ReadAsStringAsync();
            var response = await base.SendAsync(request, cancellationToken);
            var responseContent = await response.Content.ReadAsStringAsync();
            await Log(started, request, response, requestContent, responseContent);
            return response;
        }
    
        private async Task Log(DateTime start, HttpRequestMessage request, 
                                 HttpResponseMessage response, string requestContent, 
                                    string responseContent)
        {
            var finished = DateTime.UtcNow;           
            var info = new ApiLogEntry(start, finished, requestContent, responseContent, 
                                            request, response);
            Data.Log(info);
        }
    }
