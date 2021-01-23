      HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri("http://localhost:58229/");
                    client.DefaultRequestHeaders.Clear();
        
                    // Add an Accept header for JSON format.
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpRequestMessage Request = new HttpRequestMessage();
    //You need to give the method name
                    HttpResponseMessage _response = client.PostAsJsonAsync("api/SendEmail", request).Result;
