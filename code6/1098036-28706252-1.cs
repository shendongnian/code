        public async Task<string> Foo(string uri)
        {
            var client = new HttpClient();
            var response = await client.PostAsync(uri, null);
            // use this if (response.StatusCode != HttpStatusCode.OK) { do what you want }
            // or this if (response.IsSuccessStatusCode) { do what you want }
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }
