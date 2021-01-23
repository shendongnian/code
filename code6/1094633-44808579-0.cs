    public sealed class EmptyResult : IHttpActionResult
    {
        private static EmptyResult instance;
        private static object sync = new object();
        public static EmptyResult GetInstance()
        {
            if (instance == null)
            {
                lock (sync)
                {
                    return instance = new EmptyResult();
                }
            }
            return instance;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(new HttpResponseMessage(System.Net.HttpStatusCode.NoContent) { Content = new StringContent("Empty result") });
        }
    }
