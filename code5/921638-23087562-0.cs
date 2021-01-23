	// System.Net.Http.HttpClientHandler
	/// <summary>Creates an instance of  <see cref="T:System.Net.Http.HttpResponseMessage" /> based on the information provided in the <see cref="T:System.Net.Http.HttpRequestMessage" /> as an operation that will not block.</summary>
	/// <returns>Returns <see cref="T:System.Threading.Tasks.Task`1" />.The task object representing the asynchronous operation.</returns>
	/// <param name="request">The HTTP request message.</param>
	/// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
	/// <exception cref="T:System.ArgumentNullException">The <paramref name="request" /> was null.</exception>
	protected internal override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		if (request == null)
		{
			throw new ArgumentNullException("request", SR.net_http_handler_norequest);
		}
		this.CheckDisposed();
		if (Logging.On)
		{
			Logging.Enter(Logging.Http, this, "SendAsync", request);
		}
		this.SetOperationStarted();
		TaskCompletionSource<HttpResponseMessage> taskCompletionSource = new TaskCompletionSource<HttpResponseMessage>();
		HttpClientHandler.RequestState requestState = new HttpClientHandler.RequestState();
		requestState.tcs = taskCompletionSource;
		requestState.cancellationToken = cancellationToken;
		requestState.requestMessage = request;
		this.lastUsedRequestUri = request.RequestUri;
		try
		{
			HttpWebRequest httpWebRequest = this.CreateAndPrepareWebRequest(request);
			requestState.webRequest = httpWebRequest;
			cancellationToken.Register(HttpClientHandler.onCancel, httpWebRequest);
			if (ExecutionContext.IsFlowSuppressed())
			{
				IWebProxy webProxy = null;
				if (this.useProxy)
				{
					webProxy = (this.proxy ?? WebRequest.DefaultWebProxy);
				}
				if (this.UseDefaultCredentials || this.Credentials != null || (webProxy != null && webProxy.Credentials != null))
				{
					this.SafeCaptureIdenity(requestState);
				}
			}
			Task.Factory.StartNew(this.startRequest, requestState);
		}
		catch (Exception e)
		{
			this.HandleAsyncException(requestState, e);
		}
		if (Logging.On)
		{
			Logging.Exit(Logging.Http, this, "SendAsync", taskCompletionSource.Task);
		}
		return taskCompletionSource.Task;
	}
