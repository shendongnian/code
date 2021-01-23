    using (var client = new HttpClient())
                {
                    var request = new HttpRequestMessage
                    {
                        RequestUri = new Uri("..."),
                        Method = HttpMethod.Get
                    };
    
                    request.Headers.Add("X-Scitemwebapi-Username", "sitecore\admin");
                    request.Headers.Add("X-Scitemwebapi-Password", "b");
    
                    var response = await client.SendAsync(request);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseString= await response.Content.ReadAsStringAsync();
                        ...
                    }
                }
