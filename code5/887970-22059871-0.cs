    public class MockMessageInvoker : HttpMessageInvoker
    {
        public string ResponseString { get; set; }
        public MockMessageInvoker(string responseString)
            : base(new HttpClientHandler())
        {
            ResponseString = responseString;
        }
        public override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            return Task.Run<HttpResponseMessage>(() =>
            {
                HttpResponseMessage responseMessage = new HttpResponseMessage(
                    System.Net.HttpStatusCode.OK);
                var bytes = Encoding.ASCII.GetBytes(ResponseString);
                var stream = new System.IO.MemoryStream(bytes);
                responseMessage.Content = new StreamContent(stream);
                return responseMessage;
            });
        }
    }
