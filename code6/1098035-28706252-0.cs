        public async Task<string> Foo(string uri)
        {
            var client = new HttpClient();
            var response = await client.PostAsync(uri, null);
            // use response.StatusCode
            return response.StatusCode.ToString();
        }
