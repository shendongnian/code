            var baseUrl = $"https://innoviris-ai.collibra.com/rest/2.0{path}";
            using (var handler = new HttpClientHandler() { CookieContainer = CookieContainer })
            using (var client = new HttpClient(handler) {BaseAddress = new Uri(baseUrl)})
            {
                client.DefaultRequestHeaders.ConnectionClose = false;
                if (!string.IsNullOrWhiteSpace(token))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{token}");
                }
                ServicePointManager.FindServicePoint(client.BaseAddress).ConnectionLeaseTimeout = 60 * 1000; //1 minute     
                var response = await client.GetAsync(String.Empty);
                return await GetResponseContent(response);
            }
        }
