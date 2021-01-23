    internal class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            object httpListener;
    
            if (app.Properties.TryGetValue(typeof(HttpListener).FullName, out httpListener)
                && httpListener is HttpListener)
            {
                // HttpListener should not return exceptions that occur
                // when sending the response to the client
                ((HttpListener)httpListener).IgnoreWriteExceptions = true;
            }
    
            app.Use<TestOwinMiddleware>();
        }
    }
