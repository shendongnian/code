        using (var client = new HttpClient() { BaseAddress = "http://someurl.com" } )
        using (var responseMessage = await client.GetAsync("resources/123")
        {
            try
            {
                // EnsureSuccessStatusCode will throw HttpRequestException exception if 
                // status code is not successfull
                responseMessage.EnsureSuccessStatusCode();
                
                // Here you should process your response if it is successfull.
                // Something like
                // var result = await responseMessage.Content.ReadAsAsync<MyClass>();
            }
            catch (HttpRequestException)
            {
                var errorContent = await responseMessage.Content.ReadAsStringAsync();
                // "errorContent" variable will contain your exception message.
            } 
        }
