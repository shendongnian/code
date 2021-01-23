        static async Task RunAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://domain.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
       
                // HTTP POST
                var obj = new MyObject() { Str = "MyString"};
                response = await client.PostAsJsonAsync("POST URL GOES HERE?", obj );
                if (response.IsSuccessStatusCode)
                {
                    response.//.. Contains the returned content.
                }
            }
        }
