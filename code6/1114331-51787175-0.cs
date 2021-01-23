        private async Task<List<Cookie>> GetCookies(string url, string cookieName)
        {
            var cookieContainer = new CookieContainer();
            var uri = new Uri(url);
            using (var httpClientHandler = new HttpClientHandler
            {
                CookieContainer = cookieContainer
            })
            {
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    await httpClient.GetAsync(uri);
                    List<Cookie> cookies = cookieContainer.GetCookies(uri).Cast<Cookie>().ToList();
                    return cookies;
                }
            }
        }
