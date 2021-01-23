            HttpClient Client= new HttpClient();
            Client.DefaultRequestHeaders.Add("accept", "Application/JSON");
              //Add the content body (which is a json object)
            HttpContent content = new StringContent(jsonString);
            //Add the header
            content.Headers.TryAddWithoutValidation("Content-Type", "application/json");
            HttpResponseMessage response = await Client.PostAsync(new Uri(string), content);
          response.EnsureSuccessStatusCode();
          string ch = await response.Content.ReadAsStringAsync();
