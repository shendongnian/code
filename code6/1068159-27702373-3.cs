    public class StatusCodeHandler : IStatusCodeHandler  
    {  
        private readonly IRootPathProvider _rootPathProvider;  
    
        public StatusCodeHandler(IRootPathProvider rootPathProvider)  
        {  
            _rootPathProvider = rootPathProvider;  
        }  
    
        public bool HandlesStatusCode(HttpStatusCode statusCode, NancyContext context)  
        {  
            return statusCode == HttpStatusCode.NotFound;  
        }  
    
        public void Handle(HttpStatusCode statusCode, NancyContext context)  
        {  
            context.Response.Contents = stream =>  
            {  
                var filename = Path.Combine(_rootPathProvider.GetRootPath(), "content/PageNotFound.html");  
                using (var file = File.OpenRead(filename))  
                {  
                    file.CopyTo(stream);  
                }  
            };  
        }  
    }
