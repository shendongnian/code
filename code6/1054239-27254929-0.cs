    using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("baseUrl.net");
                    var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("Title", "test")
                });
                    
                    var result = client.PostAsync("/insert.php", content).Result;
                    string resultContent = "result: "+result.Content.ReadAsStringAsync().Result;
