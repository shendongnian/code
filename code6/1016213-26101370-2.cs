    public class ShutDownMiddleware
    {
        private readonly Func<IDictionary<string, object>, Task> next;
        private static int requestCount = 0;
        private static bool shutDownStateOn = false;
        public static void ShutDown()
        {
            shutDownStateOn = true;
        }
        public static int GetRequestCount()
        {
            return requestCount;
        }
        public ShutDownMiddleware(Func<IDictionary<string, object>, Task> next)
        {
            this.next = next;
        }
        public async Task Invoke(IDictionary<string, object> environment)
        {
            if (shutDownStateOn)
            {
                environment["owin.ResponseStatusCode"] = HttpStatusCode.ServiceUnavailable;
                return;
            }
            Interlocked.Increment(ref requestCount);
            try
            {
                await next.Invoke(environment);
            }
            finally
            {
                Interlocked.Decrement(ref requestCount);
            }
        }
    }
