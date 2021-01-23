    HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:56851/");
    
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
    
            HttpResponseMessage response = client.GetAsync("api/User").Result;
    
            if (response.IsSuccessStatusCode)
            {
               // do logic
            }
            else
            {
                MessageBox.Show("Error Code" + 
                response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
