    public async static Task<List<string>> Test()
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(@"http://thebaseadres.net/api/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
    
                    HttpResponseMessage response = await client.GetAsync("lastbitofurl");
                    if (response.IsSuccessStatusCode)
                    {
                        string s = await response.Content.ReadAsStringAsync();
                        List<String> test = JsonConvert.DeserializeObject<List<string>>(s);
                        return test;
                    }
                    else
                        return null;
                }
            }
