        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri("http://mywebservice.com");
        client.DefaultRequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        
        using (var result = await client.GetStreamAsync("test/example"))
        {
          var serializer = new JsonSerializer(); // this is json.net serializer
          using (var streamReader = new StreamReader(result)) {
            using (var jsonReader = new JsonTextReader(streamReader))
            {
              var obj = serializer.Deserialize<MyObject>(jsonReader);
              // you can access obj.Content now to get the content which was created by the webservice
              // in this example there will be "Hello World!"
            }
          }
        }
