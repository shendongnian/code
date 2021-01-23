    public class LoggingMiddleware : OwinMiddleware
    {
        private static Logger log = LogManager.GetLogger("WebApi");
        public LoggingMiddleware(OwinMiddleware next, IAppBuilder app)
            : base(next)
        {
        }
        public override async Task Invoke(IOwinContext context)
        {
            using (var db = new HermesEntities())
            {
               var sw = new Stopwatch();
               sw.Start();
               var logRequest = new log_Request
               {
                   Body = new StreamReader(context.Request.Body).ReadToEndAsync().Result,
                   Headers = Json.Encode(context.Request.Headers),
                   IPTo = context.Request.LocalIpAddress,
                   IpFrom = context.Request.RemoteIpAddress,
                   Method = context.Request.Method,
                   Service = "Api",
                   Uri = context.Request.Uri.ToString(),
                   UserName = context.Request.User.Identity.Name
               };
               db.log_Request.Add(logRequest);
               context.Request.Body.Position = 0;
               Stream stream = context.Response.Body;
               MemoryStream responseBuffer = new MemoryStream();
               context.Response.Body = responseBuffer;
               await Next.Invoke(context);
               responseBuffer.Seek(0, SeekOrigin.Begin);
               var responseBody = new StreamReader(responseBuffer).ReadToEnd();
               //do logging
               var logResponse = new log_Response
               {
                   Headers = Json.Encode(context.Response.Headers),
                   Body = responseBody,
                   ProcessingTime = sw.Elapsed,
                   ResultCode = context.Response.StatusCode,
                   log_Request = logRequest
               };
               db.log_Response.Add(logResponse);
               responseBuffer.Seek(0, SeekOrigin.Begin);
               await responseBuffer.CopyToAsync(stream);
               await db.SaveChangesAsync();
            }
        }
    }
