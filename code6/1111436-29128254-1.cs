    public class LoggingHandler : DelegatingHandler
    {
        public LoggingHandler()
            : this(new HttpClientHandler())
        { }
        public LoggingHandler(HttpMessageHandler innerHandler)
            : base(innerHandler)
        { }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var activityId = Guid.NewGuid();
            using (new Tracer("Service Call", activityId))
            {
                var entry = new LogEntry { Severity = TraceEventType.Verbose, Title = "Request" };
                if (Logger.ShouldLog(entry))
                {
                    entry.Message = request.ToString();
                    if (request.Content != null)
                    {
                        entry.Message += Environment.NewLine;
                        entry.Message += await request.Content
                            .ReadAsStringAsync()
                            .ConfigureAwait(false);
                    }
                    Logger.Write(entry);
                }
                var response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
                entry = new LogEntry { Severity = TraceEventType.Verbose, Title = "Response" };
                if (Logger.ShouldLog(entry))
                {
                    entry.Message = response.ToString();
                    if (response.Content != null)
                        entry.Message += await response.Content
                            .ReadAsStringAsync()
                            .ConfigureAwait(false);
                    
                    Logger.Write(entry);
                }
                return response;
            }
        }
    }
