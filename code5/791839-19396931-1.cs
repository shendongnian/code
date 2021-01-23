    public static void Post(Testing testing)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:3471/");
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            // Create the JSON formatter.
            MediaTypeFormatter jsonFormatter = new JsonMediaTypeFormatter();
            // Use the JSON formatter to create the content of the request body.
            HttpContent content = new ObjectContent<Testing>(testing, jsonFormatter);
            // Send the request.
            var resp = client.PostAsync("api/test/helloworld", content).Result;
        }
