    private async Task DoCallWSAsync()
    {
       string url = "<my_url>";
       // HTTP web request
       var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
       httpWebRequest.ContentType = "text/xml";
       httpWebRequest.Method = "POST";
       // Write the request Asynchronously 
       using (var stream = await Task.Factory.FromAsync<Stream>(httpWebRequest.BeginGetRequestStream,
                                                                 httpWebRequest.EndGetRequestStream, null))
       {
           string requestXml = "<my_request_xml>";
           // convert request to byte array
           byte[] requestAsBytes = Encoding.UTF8.GetBytes(requestXml);
           // Write the bytes to the stream
           await stream.WriteAsync(requestAsBytes , 0, requestAsBytes .Length);
        }
        using (WebResponse responseObject = await Task<WebResponse>.Factory.FromAsync(httpWebRequest.BeginGetResponse, httpWebRequest.EndGetResponse, httpWebRequest))
        {
            var responseStream = responseObject.GetResponseStream();
            var sr = new StreamReader(responseStream);
            string received = await sr.ReadToEndAsync();
            return received;
        }
    }
