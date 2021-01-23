    using AppFunc = Func<IDictionary<string, object>, Task>;
    
    public class CustomMiddleware
    {
        private readonly AppFunc next;
    
        public CustomMiddleware(AppFunc next)
        {
            this.next = next;
        }
    
        public async Task Invoke(IDictionary<string, object> env)
        {
            IOwinContext context = new OwinContext(env);
    
            // Buffer the response
            var stream = context.Response.Body;
            var buffer = new MemoryStream();
            context.Response.Body = buffer;
    
            await this.next(env);
    
            buffer.Seek(0, SeekOrigin.Begin);
            var reader = new StreamReader(buffer);
            string responseBody = await reader.ReadToEndAsync();
    
            // Now, you can access response body.
            Debug.WriteLine(responseBody);
    
            // You need to do this so that the response we buffered
            // is flushed out to the client application.
            buffer.Seek(0, SeekOrigin.Begin);
            await buffer.CopyToAsync(stream);
        }
    }
