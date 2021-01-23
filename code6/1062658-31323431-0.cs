    public static class HttpResponseMessageExtensions
    {
        [DebuggerStepThrough]
        public static async Task<T> ToAsync<T>(this HttpResponseMessage response, [CallerMemberName] string callerName = null, [CallerFilePath] string callerFilePath = null, [CallerLineNumber] int callerLine = -1)
        {
            if (!response.IsSuccessStatusCode)
            {
                var message = string.Format("There was a problem extracting the content from the response. Status: {0}. Reason: {1}. Calling method is {2} in {3}:line {4}", response.StatusCode, response.ReasonPhrase, callerName, callerFilePath, callerLine);
                var exception = new Exception(message);
                throw exception;
            }
    
            var stringContent = await response.Content.ReadAsStringAsync();
    
            return JsonConvert.DeserializeObject<T>(stringContent);
        }
    }
