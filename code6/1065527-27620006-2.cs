    public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, HttpCompletionOption completionOption, CancellationToken cancellationToken)
    {
    	if (request == null)
    	{
    		throw new ArgumentNullException("request");
    	}
    	this.CheckDisposed();
    	HttpClient.CheckRequestMessage(request);
    	this.SetOperationStarted();
    	this.PrepareRequestMessage(request);
    	CancellationTokenSource linkedCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, this.pendingRequestsCts.Token);
    	TimerThread.Timer timeoutTimer = this.SetTimeout(linkedCts);
    	TaskCompletionSource<HttpResponseMessage> tcs = new TaskCompletionSource<HttpResponseMessage>();
    	try
    	{
    		base.SendAsync(request, linkedCts.Token).ContinueWithStandard(delegate(Task<HttpResponseMessage> task)
    		{
    			try
    			{
    				this.DisposeRequestContent(request);
    				if (task.IsFaulted)
    				{
    					this.SetTaskFaulted(request, linkedCts, tcs, task.Exception.GetBaseException(), timeoutTimer);
    				}
    				else
    				{
    					if (task.IsCanceled)
    					{
    						this.SetTaskCanceled(request, linkedCts, tcs, timeoutTimer);
    					}
    					else
    					{
    						HttpResponseMessage result = task.Result;
    						if (result == null)
    						{
    							this.SetTaskFaulted(request, linkedCts, tcs, new InvalidOperationException(SR.net_http_handler_noresponse), timeoutTimer);
    						}
    						else
    						{
    							if (result.Content == null || completionOption == HttpCompletionOption.ResponseHeadersRead)
    							{
    								this.SetTaskCompleted(request, linkedCts, tcs, result, timeoutTimer);
    							}
    							else
    							{
    								this.StartContentBuffering(request, linkedCts, tcs, result, timeoutTimer);
    							}
    						}
    					}
    				}
    			}
    			catch (Exception ex)
    			{
    				if (Logging.On)
    				{
    					Logging.Exception(Logging.Http, this, "SendAsync", ex);
    				}
    				tcs.TrySetException(ex);
    			}
    		});
    	}
    	catch
    	{
    		HttpClient.DisposeTimer(timeoutTimer);
    		throw;
    	}
    	return tcs.Task;
