        public T HttpPostMultiPartFileStream<T>(string requestURL, string filePath, string fileName)
        {
            string content = null;
    
            using (MultipartFormDataContent form = new MultipartFormDataContent())
            {
                StreamContent streamContent;
                using (var fileStream = new FileStream(filePath, FileMode.Open))
                {
                    streamContent = new StreamContent(fileStream);
    
                    streamContent.Headers.Add("Content-Type", "application/octet-stream");
                    streamContent.Headers.Add("Content-Disposition", string.Format("form-data; name=\"file\"; filename=\"{0}\"", fileName));
                    form.Add(streamContent, "file", fileName);
    
                    using (HttpClient client = GetAuthenticatedHttpClient())
                    {
                        HttpResponseMessage response = client.PostAsync(requestURL, form).GetAwaiter().GetResult();
                        content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
    
                     
    
                        try
                        {
                            return JsonConvert.DeserializeObject<T>(content);
                        }
                        catch (Exception ex)
                        {
                            // Log the exception
                        }
    
                        return default(T);
                    }
                }
            }
        }
