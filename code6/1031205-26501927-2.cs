        using (var client = new System.Net.Http.HttpClient())
        {
            using (var multipartFormDataContent = new MultipartFormDataContent())
            {
                var values = new[]
                {
                    new KeyValuePair<string, string>("ApiKey", "YourApiKey")
                };
                foreach (var keyValuePair in values)
                {
                    multipartFormDataContent.Add(new StringContent(keyValuePair.Value), String.Format("\"{0}\"", keyValuePair.Key));
                }
                multipartFormDataContent.Add(new ByteArrayContent(File.ReadAllBytes(@"C:\test.docx")), '"' + "File" + '"', '"' + "test.docx" + '"');
                const string requestUri = "http://do.convertapi.com/word2pdf";
                var response = await client.PostAsync(requestUri, multipartFormDataContent);
                if (response.IsSuccessStatusCode)
                {
                    var responseHeaders = response.Headers;
                    var paths = responseHeaders.GetValues("OutputFileName").First();
                    var path = Path.Combine(@"C:\", paths);
                    File.WriteAllBytes(path, await response.Content.ReadAsByteArrayAsync());
                }
                else
                {
                    Console.WriteLine("Status Code : {0}", response.StatusCode);
                    Console.WriteLine("Status Description : {0}", response.ReasonPhrase);
                }
            }
        }
