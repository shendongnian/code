    using System;
    using System.IO;
    using CefSharp;
    
    namespace MyProject.CustomProtocol
    {
        public class CustomProtocolSchemeHandler : ResourceHandler
        {
            // Specifies where you bundled app resides.
            // Basically path to your index.html
            private string frontendFolderPath;
    
            public CustomProtocolSchemeHandler()
            {
                frontendFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "./bundle/");
            }
    
            // Process request and craft response.
            public override bool ProcessRequestAsync(IRequest request, ICallback callback)
            {
                var uri = new Uri(request.Url);
                var fileName = uri.AbsolutePath;
    
                var requestedFilePath = frontendFolderPath + fileName;
    
                if (File.Exists(requestedFilePath))
                {
                    byte[] bytes = File.ReadAllBytes(requestedFilePath);
                    Stream = new MemoryStream(bytes);
    
                    var fileExtension = Path.GetExtension(fileName);
                    MimeType = GetMimeType(fileExtension);
    
                    callback.Continue();
                    return true;
                }
    
                callback.Dispose();
                return false;
            }
        }
        public class CustomProtocolSchemeHandlerFactory : ISchemeHandlerFactory
        {
            public const string SchemeName = "customFileProtocol";
        
            public IResourceHandler Create(IBrowser browser, IFrame frame, string schemeName, IRequest request)
            {
                return new CustomProtocolSchemeHandler();
            }
        }
    }
