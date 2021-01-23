	// System.Net.Http.HttpClientHandler
	private void PrepareAndStartContentUpload(HttpClientHandler.RequestState state)
	{
		HttpContent requestContent = state.requestMessage.Content;
		try
		{
			if (state.requestMessage.Headers.TransferEncodingChunked == true)
			{
				state.webRequest.SendChunked = true;
				this.StartGettingRequestStream(state);
			}
			else
			{
				long? contentLength = requestContent.Headers.ContentLength;
				if (contentLength.HasValue)
				{
					state.webRequest.ContentLength = contentLength.Value;
					this.StartGettingRequestStream(state);
				}
				else
				{
					if (this.maxRequestContentBufferSize == 0L)
					{
						throw new HttpRequestException(SR.net_http_handler_nocontentlength);
					}
					requestContent.LoadIntoBufferAsync(this.maxRequestContentBufferSize).ContinueWithStandard(delegate(Task task)
					{
						if (task.IsFaulted)
						{
							this.HandleAsyncException(state, task.Exception.GetBaseException());
							return;
						}
						contentLength = requestContent.Headers.ContentLength;
						state.webRequest.ContentLength = contentLength.Value;
						this.StartGettingRequestStream(state);
					});
				}
			}
		}
		catch (Exception e)
		{
			this.HandleAsyncException(state, e);
		}
	}
