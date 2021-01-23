        private string GetResponseString(string text)
        {
            var httpClient = new HttpClient();
            var parameters = new Dictionary<string, string>();
            parameters["text"] = text;
            var response = httpClient.PostAsync(BaseUri, new FormUrlEncodedContent(parameters)).Result;
            var contents = response.Content.ReadAsStringAsync().Result;
         }  
