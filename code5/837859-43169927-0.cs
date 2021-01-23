	public class HttpClientDownloadWithProgress : IDisposable
	{
		private readonly string _downloadUrl;
		private readonly string _destinationFilePath;
		private HttpClient _httpClient;
		public delegate void ProgressChangedHandler(double progressPercentage);
		public event ProgressChangedHandler ProgressChanged;
		public HttpClientDownloadWithProgress(string downloadUrl, string destinationFilePath)
		{
			_downloadUrl = downloadUrl;
			_destinationFilePath = destinationFilePath;
		}
		public async Task StartDownload()
		{
			_httpClient = new HttpClient { Timeout = TimeSpan.FromDays(1) };
			using (var response = _httpClient.GetAsync(_downloadUrl, HttpCompletionOption.ResponseHeadersRead).Result)
			{
				response.EnsureSuccessStatusCode();
				var totalBytes = response.Content.Headers.ContentLength;
				using (var contentStream = await response.Content.ReadAsStreamAsync())
				{
					var totalBytesRead = 0L;
					var readCount = 0L;
					var buffer = new byte[8192];
					var isMoreToRead = true;
					using (var fileStream = new FileStream(_destinationFilePath, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true))
					{
						do
						{
							var bytesRead = await contentStream.ReadAsync(buffer, 0, buffer.Length);
							if (bytesRead == 0)
							{
								isMoreToRead = false;
							}
							else
							{
								await fileStream.WriteAsync(buffer, 0, bytesRead);
								totalBytesRead += bytesRead;
								readCount += 1;
								if (readCount % 2000 != 0 || !totalBytes.HasValue || ProgressChanged == null) continue;
								var progressPercentage = Math.Round((double)totalBytesRead / totalBytes.Value * 100, 2);
								ProgressChanged(progressPercentage);
							}
						}
						while (isMoreToRead);
					}
				}
			}
		}
		public void Dispose()
		{
			_httpClient?.Dispose();
		}
	}
