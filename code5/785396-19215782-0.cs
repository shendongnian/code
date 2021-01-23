    public static class Extensions {
        public static async Task<HttpWebResponse> GetResponseAsync(this HttpWebRequest request, CancellationToken ct)
        {
            var cts = CancellationTokenSource.CreateLinkedTokenSource(ct);
            cts.Token.Register(() => request.Abort(), useSynchronizationContext: true);
            using (cts)
            {
                return (HttpWebResponse)await request.GetResponseAsync();
            }
        }
    }
