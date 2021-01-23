                using (var handler = new HttpClientHandler() { CookieContainer = new CookieContainer() })
                {
                    using (var client = new HttpClient(handler)
                    { BaseAddress = new Uri("site.com") })
                    {
                        //add parameters on request
                        var body = new List<KeyValuePair<string, string>>
                        {
                            new KeyValuePair<string, string>("test", "test"),
                            new KeyValuePair<string, string>("test1", "test1")
                        };
    
                        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "site.com");
    
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded; charset=UTF-8"));
                        client.DefaultRequestHeaders.Add("Upgrade-Insecure-Requests", "1");
                        client.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");
                        client.DefaultRequestHeaders.Add("X-MicrosoftAjax", "Delta=true");
                        //client.DefaultRequestHeaders.Add("Accept", "*/*");
    
                        client.Timeout = TimeSpan.FromMilliseconds(10000);
    
                        var res = await client.PostAsync("", new FormUrlEncodedContent(body));
    
                        if (res.IsSuccessStatusCode)
                        {
                            var exec = await res.Content.ReadAsStringAsync();
                            Console.WriteLine(exec);
                        }                    
                    }
                }
