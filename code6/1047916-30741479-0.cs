    using AppFunc = Func<
           IDictionary<string, object>, // Environment
           Task>; // Done
    public static class AngularServerExtension
    {
        public static IAppBuilder UseAngularServer(this IAppBuilder builder, string rootPath, string entryPath)
        {
            var options = new AngularServerOptions()
            {
                FileServerOptions = new FileServerOptions()
                {
                    EnableDirectoryBrowsing = false,
                    FileSystem = new PhysicalFileSystem(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, rootPath))
                },
                EntryPath = new PathString(entryPath)
            };
            builder.UseDefaultFiles(options.FileServerOptions.DefaultFilesOptions);
            return builder.Use(new Func<AppFunc, AppFunc>(next => new AngularServerMiddleware(next, options).Invoke));    
        }
    }
    public class AngularServerOptions
    {
        public FileServerOptions FileServerOptions { get; set; }
        public PathString EntryPath { get; set; }
        public bool Html5Mode
        {
            get
            {
                return EntryPath.HasValue;
            }
        }
        public AngularServerOptions()
        {
            FileServerOptions = new FileServerOptions();
            EntryPath = PathString.Empty;
        }
    }
    public class AngularServerMiddleware
    {
        private readonly AngularServerOptions _options;
        private readonly AppFunc _next;
        private readonly StaticFileMiddleware _innerMiddleware;
        public AngularServerMiddleware(AppFunc next, AngularServerOptions options)
        {
            _next = next;
            _options = options;
            _innerMiddleware = new StaticFileMiddleware(next, options.FileServerOptions.StaticFileOptions);
        }
        public async Task Invoke(IDictionary<string, object> arg)
        {
            await _innerMiddleware.Invoke(arg);
            // route to root path if the status code is 404
            // and need support angular html5mode
            if ((int)arg["owin.ResponseStatusCode"] == 404 && _options.Html5Mode)
            {
                arg["owin.RequestPath"] = _options.EntryPath.Value;
                await _innerMiddleware.Invoke(arg);
            }
        }
    }
