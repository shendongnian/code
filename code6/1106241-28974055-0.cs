    public static class FlurlHttpExtensions
    {
        /// <summary>
        /// Sends an asynchronous POST request of specified data (usually an anonymous object or dictionary) formatted as XML.
        /// </summary>
        /// <param name="client">The FlurlClient</param>
        /// <param name="serializedXml">Data to be serialized and posted.</param>
        /// <returns>A Task whose result is the received HttpResponseMessage.</returns>
        public static Task<HttpResponseMessage> PostXmlAsync(this FlurlClient client, string serializedXml)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, client.Url.ToString())
            {
                Content = new CapturedStringContent(serializedXml, Encoding.UTF8, "text/xml"),
                Method = HttpMethod.Post
            };
            return client.HttpClient.SendAsync(request);
        }
    }
