    public static class FlurlXmlExtensions
    {
        // chain off an existing FlurlClient:
        public static async Task<HttpResponseMessage> PostXmlAsync(this FlurlClient fc, string xml) {
            try {
                var content = new CapturedStringContent(xml, Encoding.UTF8, "application/xml");
                return await fc.HttpClient.PostAsync(fc.Url, content);
            }
            finally {
                if (AutoDispose)
                    Dispose();
            }
        }
        // chain off a Url object:
        public static Task<HttpResponseMessage> PostXmlAsync(this Url url, string xml) {
            return new FlurlClient(url, true).PostXmlAsync(xml);
        }
        // chain off a url string:
        public static Task<HttpResponseMessage> PostXmlAsync(this string url, string xml) {
            return new FlurlClient(url, true).PostXmlAsync(xml);
        }
    }
