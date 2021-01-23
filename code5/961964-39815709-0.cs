    public class ResponseMiddleware 
    {
        AppFunc _next;
        ResponseMiddlewareOptions _options;
    
        public ResponseMiddleware(AppFunc nex, ResponseMiddlewareOptions options)
        {
            _next = next;
        }
    
        public async Task Invoke(IDictionary<string, object> environment)
        {
            var context = new OwinContext(environment);
    
            await _next(environment);
    
            if (context.Response.StatusCode == 400 && context.Response.Headers.ContainsKey("Change_Status_Code"))
            {
                //read the status code sent in the response
                var headerValues = context.Response.Headers.GetValues("Change_Status_Code");
                //replace the original status code with the new one
                context.Response.StatusCode = Convert.ToInt16(headerValues.FirstOrDefault());
                //remove the unnecessary header flag
                context.Response.Headers.Remove("Change_Status_Code");
            }
        }
    }
