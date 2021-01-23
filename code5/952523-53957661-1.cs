    public async Task<string> TranscribeLongMediaFile(string operationName)
        {
            string bearerToken = GetOAuthToken();
            var baseUrl = new Uri(googleSpeechBaseUrl + operationName);
            string resultContent = string.Empty;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add(HttpRequestHeader.Authorization.ToString(), "Bearer " + bearerToken);
                client.DefaultRequestHeaders.Add(HttpRequestHeader.ContentType.ToString(), "application/json; charset=utf-8");
                client.Timeout = TimeSpan.FromMilliseconds(Timeout.Infinite);
                int currentPercentage = 0;
                bool responseStatus = false;
                while (!responseStatus)
                {
                    responseStatus = false;
                    // Send request
                    using (var result = await client.GetAsync(baseUrl))
                    {
                        resultContent = await result.Content.ReadAsStringAsync();
                        ResponseObject responseObject = JsonConvert.DeserializeObject<ResponseObject>(resultContent);
                        currentPercentage = responseObject.metadata.progressPercent;
                        responseStatus = (responseObject.done && currentPercentage == 100);
                        // Delay the request based on percentage value to repeatedly making the GET request until the done property of the response is true.
                        await Task.Delay(CalculateDealy(currentPercentage));
                    }
                }
            };
            return resultContent;
        }
