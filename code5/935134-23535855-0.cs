     string jsonText = json.ToString();
     using (var client = new HttpClient())
     {
          var httpContent = new StringContent(jsonString);
          httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
          
          HttpResponseMessage message = await client.PostAsync("http://myWebUrl/send", httpContent);
     }
