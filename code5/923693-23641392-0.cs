    HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost/myproject/");
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            var t = client.GetAsync("api/values");
            t.ContinueWith(p =>
            {
                if (p.Result.IsSuccessStatusCode)
                {
                    var users = p.Result.Content.ReadAsByteArrayAsync().Result;
                    if (users != null)
                    {
                    }
                }
               
            });
