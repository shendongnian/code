        public static CookieContainer CookieContainer;
        public static async Task<string> Post<TRequest>( TRequest requestBody, string path, string token = "")
        {
            var baseUrl = new Uri($"urlFromApi");
            CookieContainer = new CookieContainer();
            using (var handler = new HttpClientHandler() { CookieContainer = CookieContainer })
                using(var client = new HttpClient(handler){BaseAddress = baseUrl})
            {
                client.DefaultRequestHeaders.ConnectionClose = false;
                if (!string.IsNullOrWhiteSpace(token))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{token}");
                }
                ServicePointManager.FindServicePoint(client.BaseAddress).ConnectionLeaseTimeout = 60 * 1000; //1 minute            using (var content = new ByteArrayContent(GetByteData(requestBody)))
                using (var content = new ByteArrayContent(GetByteData(requestBody)))
                {
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    var response = await client.PostAsync(String.Empty, content);
                    return await GetResponseContent(response);
                }
            }
            
        }
