    public static class Extensions
    {
        public static async Task<HttpWebResponse> GetResponseAsync(this HttpWebRequest request, CancellationToken ct)
        {
            var cts = CancellationTokenSource.CreateLinkedTokenSource(ct);
            cts.Token.Register(() => request.Abort(), useSynchronizationContext: false);
            using (cts)
            {
                var response = await request.GetResponseAsync();
                ct.ThrowIfCancellationRequested();
                return (HttpWebResponse)response;
            }
        }
    }
