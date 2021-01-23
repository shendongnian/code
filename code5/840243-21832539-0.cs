	public static class WebClientExtensions
	{
		public static async Task<byte[]> DownloadDataTaskAsync(this WebClient obj, string address, CancellationToken cancellationToken)
		{
			cancellationToken.Register(obj.CancelAsync);
			return await obj.DownloadDataTaskAsync(address);
		}
	}
