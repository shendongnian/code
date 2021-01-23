    public static async Task<string> GetHttpAsStringTask(string uriString)
        {
            string result;
            Uri targetUri = new Uri(uriString);
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, targetUri);
            //Add your empty header here
            request.Headers.Add("Header name","header value");
            HttpResponseMessage response = await client.SendAsync(request);
            using (Stream responseStream = await response.Content.ReadAsStreamAsync())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                result = reader.ReadToEnd();
            }
            return result;
        }
