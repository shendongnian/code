    async Task<HttpResponseMessage> PostAsync(
        Uri uri,
        IEnumerable<KeyValuePair<string, string>> parameters = null,
        IEnumerable<Cookie> cookies = null)
        {
            if (parameters == null)
            {
                parameters = new Dictionary<string, string>();
            }
            using (HttpClientHandler handler = new HttpClientHandler())
            {
                handler.CookieContainer = new CookieContainer();
                if (cookies != null)
                {
                    foreach (Cookie cookie in cookies)
                    {
                        handler.CookieContainer.Add(cookie);
                    }
                }
                using (HttpClient client = new HttpClient(handler))
                {
                    using (HttpContent content = new FormUrlEncodedContent(parameters))
                    {
                        return await client.PostAsync(uri, content);
                    }
                }
            }
        }
