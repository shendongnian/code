    public static class Extensions
    {
        public static async Task<HttpWebResponse> GetResponseAsync(this HttpWebRequest request, CancellationToken ct)
        {
            using (ct.Register(() => request.Abort(), useSynchronizationContext: false))
            {
                var response = await request.GetResponseAsync();
                ct.ThrowIfCancellationRequested();
                return (HttpWebResponse)response;
            }
        }
    }
