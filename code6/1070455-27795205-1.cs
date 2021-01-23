    class WebClientToDownload
    {
        // Notice this now returns a Task<string>.  This will allow you to await on the data being returned.
        public async Task<string> DownloadFile(string url)
        {
            string baseurl = "http://api.openweathermap.org/data/2.5/forecast/daily?q=";
            StringBuilder sb = new StringBuilder(baseurl);
            sb.Append(url + "&mode=json&units=metric&cnt=7");
            string actual = sb.ToString();
            HttpClient http = new System.Net.Http.HttpClient();
            HttpResponseMessage response = await http.GetAsync(actual);
            // Return the result rather than setting a variable.
            return await response.Content.ReadAsStringAsync();
        }
    }
