        public async Task<string> Foo(string uri)
        {
            var client = new HttpClient();
            try
            {
                var response = await client.PostAsync(uri, null);
            }
            catch (Exception ex)
            {
                //here you handle exceptions
            }
            // use this if (response.StatusCode != HttpStatusCode.OK) { do what you want }
            // or this if (response.IsSuccessStatusCode) { do what you want }
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }
