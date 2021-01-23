    public sealed class UrlTester : IUrlTester
    {
        private readonly HttpClient httpClient = new HttpClient();
        public UrlTestResult TestUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentNullException("url");
            }
            try
            {
                Task<HttpResponseMessage> message = httpClient.GetAsync(url);
                if (message == null || message.Result == null)
                {
                    return new FailedUrlTestResult(url, "No response was returned.");
                }
                if (message.Result.StatusCode == HttpStatusCode.OK)
                {
                    return new SuccessfulUrlTestResult(url);
                }
                return new FailedUrlTestResult(url, "{0}: {1}".FormatCurrentCulture((int)message.Result.StatusCode, message.Result.ReasonPhrase));
            }
            catch (Exception ex)
            {
                return new FailedUrlTestResult(url, "An exception occurred: " + ex);
            }
        }
        public void Dispose()
        {
            if (httpClient != null)
            {
                httpClient.Dispose();
            }
        }
    }
