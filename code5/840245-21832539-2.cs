    public static class WebClientExtensions
    {
        public static async Task<byte[]> DownloadDataTaskAsync(this WebClient webClient, string address, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            using (cancellationToken.Register(webClient.CancelAsync))
            {
                return await webClient.DownloadDataTaskAsync(address);
            }
        }
    }
