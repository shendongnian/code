	public static class WebClientExtensions
	{
		public static async Task<byte[]> DownloadDataTaskAsync(this WebClient obj, string address, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			cancellationToken.Register(obj.CancelAsync);
			return await obj.DownloadDataTaskAsync(address);
		}
	}
