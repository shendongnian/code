    public class RetryDelegatingHandler : DelegatingHandler {
      public TimmeSpan PerRequestTimeout { get; set; }
      ...
      protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
      {
        var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        cts.CancelAfter(PerRequestTimeout);
        var token = cts.Token;
        ...
            responseMessage = await base.SendAsync(request, token);
        ...
      }
    }
