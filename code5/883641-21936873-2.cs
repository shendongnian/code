	public class ResponseSizeHandler : DelegatingHandler
	{
		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			var response = await base.SendAsync(request, cancellationToken);
			if (response.Content != null)
			{
			   await response.Content.LoadIntoBufferAsync();
			   var bodylength = response.Content.Headers.ContentLength;
			   var headerlength = response.Headers.ToString().Length;
			}
			return response;
		}
	}
