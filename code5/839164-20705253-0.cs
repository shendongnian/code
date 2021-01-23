            [Fact]
            public async Task Getting_a_response_when_offline()
            {
                var offlineHandler = new OfflineHandler(new HttpClientHandler(), new Uri("http://oak:1001/status"));
                offlineHandler.AddOfflineResponse(new Uri("http://oak:1001/ServerNotRunning"), 
                    new HttpResponseMessage(HttpStatusCode.NonAuthoritativeInformation)
                    {
                        Content = new StringContent("Here's an old copy of the information while we are offline.")
                    });
                
                var httpClient = new HttpClient(offlineHandler);
    
                var retry = true;
    
                while (retry)
                {
                    var response = await httpClient.GetAsync(new Uri("http://oak:1001/ServerNotRunning"));
    
                    if (response.StatusCode == HttpStatusCode.OK) retry = false;
                    Thread.Sleep(10000);
                }
            }
    
    
            public class OfflineHandler : DelegatingHandler
            {
                private readonly Uri _statusMonitorUri;
                private readonly Dictionary<Uri, HttpResponseMessage> _offlineResponses = new Dictionary<Uri, HttpResponseMessage>();
                private bool _isOffline = false;
                private Timer _timer;
    
                public OfflineHandler(HttpMessageHandler innerHandler, Uri statusMonitorUri)
                {
                    _statusMonitorUri = statusMonitorUri;
                    InnerHandler = innerHandler;
                }
    
                public void AddOfflineResponse(Uri uri, HttpResponseMessage response)
                {
                    _offlineResponses.Add(uri,response);
                }
    
                protected  async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
                {
                    if (_isOffline == true) return OfflineResponse(request);
    
                    try
                    {
                        var response = await base.SendAsync(request, cancellationToken);
                        if (response.StatusCode == HttpStatusCode.ServiceUnavailable || response.StatusCode == HttpStatusCode.BadGateway)
                        {
                            MonitorOfflineState();
                            return OfflineResponse(request);
                        }
                        return response;
                    }
                    catch (WebException ex)
                    {
                        MonitorOfflineState();
                        return OfflineResponse(request);
                    }
    
                }
    
                private void MonitorOfflineState()
                {
                    _isOffline = true;
                    _timer = new Timer( async state =>
                    {
                        var request = new HttpRequestMessage() {RequestUri = _statusMonitorUri};
                        try
                        {
                            var response = await base.SendAsync(request, new CancellationToken());
                            if (response.StatusCode == HttpStatusCode.OK)
                            {
                                _isOffline = false;
                                _timer.Dispose();
                            } 
                        }
                        catch
                        {
                            
                        }
                    }, null, new TimeSpan(0,0,0),new TimeSpan(0,1,0));
                    
                }
    
                private HttpResponseMessage OfflineResponse(HttpRequestMessage request)
                {
                    if (_offlineResponses.ContainsKey(request.RequestUri))
                    {
                        return _offlineResponses[request.RequestUri];
                    }
                    return new HttpResponseMessage(HttpStatusCode.ServiceUnavailable);
                }
            }
        }
