    static HttpResponseMessage UploadFileWithParam(string requestUri, string fileName, string key1, string val1)
    {
        using (var client = new HttpClient())
        {
            using (var content = new MultipartFormDataContent())
            {
                content.Add(new StringContent(val1), key1);
                var fileContent = new StreamContent(File.OpenRead(fileName));
                fileContent.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                {
                    FileName = fileName
                };
                content.Add(fileContent);
                return client.PostAsync(requestUri, content).Result;
            }
        }
    }
    
    // UploadFileWithParam("http://example.com", @"c:\...", "param1", "value1").Dump();
