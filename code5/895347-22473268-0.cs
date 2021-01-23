    public class ContentValidationHandler : DelegatingHandler
    {
        private static log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);
            
            Stream strea = new MemoryStream();
            await request.Content.CopyToAsync(strea);
            strea.Position = 0;
            StreamReader reader = new StreamReader(strea);
            String res = reader.ReadToEnd();
            Log.Info("request content: " + res);
            return response;
            
            //
        }
    }
