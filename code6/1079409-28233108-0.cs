	public Task<Stream> ReadAsStreamAsync()
	{
		this.CheckDisposed();
		TaskCompletionSource<Stream> tcs = new TaskCompletionSource<Stream>();
		if (this.contentReadStream == null && this.IsBuffered)
		{
			this.contentReadStream = new MemoryStream(this.bufferedContent.GetBuffer(),
                                                      0, (int)this.bufferedContent.Length,
                                                      false, false);
		}
		if (this.contentReadStream != null)
		{
			tcs.TrySetResult(this.contentReadStream);
			return tcs.Task;
		}
		this.CreateContentReadStreamAsync().ContinueWithStandard(delegate(Task<Stream> task)
		{
			if (!HttpUtilities.HandleFaultsAndCancelation<Stream>(task, tcs))
			{
				this.contentReadStream = task.Result;
				tcs.TrySetResult(this.contentReadStream);
			}
		});
		return tcs.Task;
	}
