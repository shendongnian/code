        public static TItem GetItem<TItem>(this HttpClient httpClient, string queryString) where TItem : class
        {
            var response = httpClient.GetAsync(queryString).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<TItem>().Result;
            }
            throw new HttpRequestException(response.ToString());
        }
