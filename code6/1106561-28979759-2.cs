            public async Task<string> _MakeRequestAsync(string parameters) 
            {
                var uri = new Uri(EndPoint + parameters);
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(uri);
                    return await result.Content.ReadAsStringAsync();
                };
            }
