    public class MyLoader()
    {
        protected HttpMessageInvoker MessageInvoker { get; set; }
        private HttpRequestMessage requestMessage;
        public MyLoader()    // default constructor
        {
            MessageInvoker = new HttpClient();
        }
        public MyLoader(HttpMessageInvoker httpMessageInvoker)
        {
            MessageInvoker = httpMessageInvoker;
        }
        public object DoSomething()
        {
            var response = await MessageInvoker.SendAsync(requestMessage, cancellationTokenSource.Token);
        }
