    public static class HttpRequestMessageExtensions
    {
        public static async Task<T> GetAsT<T>(this HttpRequestMessage request)
        {
            using (var client = new HttpClient())
            {
                var response = await client.SendAsync(request);
                return await response.Content.ReadAsAsync<T>();
            }
        }
    }
