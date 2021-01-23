    private void CallPostHttpClient()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:44354/api/test/");
            var responseTask = httpClient.PostAsync("PostJson", null);
            responseTask.Wait();
            var result = responseTask.Result;
            var readTask = result.Content.ReadAsStringAsync().Result;
        }
        private void CallGetHttpClient()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:44354/api/test/");
            var responseTask = httpClient.GetAsync("getjson");
            responseTask.Wait();
            var result = responseTask.Result;
            var readTask = result.Content.ReadAsStringAsync().Result;
        }
        private string CallGetWebRequest()
        {
            var request = (HttpWebRequest)WebRequest.Create("https://localhost:44354/api/test/getjson");
            request.Method = "GET";
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            var content = string.Empty;
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    using (var sr = new StreamReader(stream))
                    {
                        content = sr.ReadToEnd();
                    }
                }
            }
            return content;
        }
        private string CallPostWebRequest()
        {
            var apiUrl = "https://localhost:44354/api/test/PostJson";
            HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(new Uri(apiUrl));
            httpRequest.ContentType = "application/json";
            httpRequest.Method = "POST";
            httpRequest.ContentLength = 0;
            using (var httpResponse = (HttpWebResponse)httpRequest.GetResponse())
            {
                using (Stream stream = httpResponse.GetResponseStream())
                {
                    var json = new StreamReader(stream).ReadToEnd();
                    return json;
                }
            }
            return "";
        }
        private string CallGetWebClient()
        {
            string apiUrl = "https://localhost:44354/api/test/getjson";
            var client = new WebClient();
            client.Headers["Content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            var json = client.DownloadString(apiUrl);
            return json;
        }
        private string CallPostWebClient()
        {
            string apiUrl = "https://localhost:44354/api/test/PostJson";
            var client = new WebClient();
            client.Headers["Content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            var json = client.UploadString(apiUrl, "");
            return json;
        }
