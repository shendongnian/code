    namespace Owin
    {
        using AppFunc = Func<IDictionary<string, object>, Task>;
    
        public static class AppBuilderExtensions
        {
            public static IAppBuilder UseHtml5Mode(this IAppBuilder app, string rootPath, string entryPath)
            {
                if (app == null) throw new ArgumentNullException(nameof(app));
                if (rootPath == null) throw new ArgumentNullException(nameof(rootPath));
                if (entryPath == null) throw new ArgumentNullException(nameof(entryPath));
    
                var options = new Html5ModeOptions
                {
                    EntryPath = new PathString(entryPath),
                    FileServerOptions = new FileServerOptions()
                    {
                        EnableDirectoryBrowsing = false,
                        FileSystem = new PhysicalFileSystem(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, rootPath))
                    }
                };
    
                app.UseDefaultFiles(options.FileServerOptions.DefaultFilesOptions);
    
                return app.Use(new Func<AppFunc, AppFunc>(next => new Html5ModeMiddleware(next, options).Invoke));
            }
        }
    }
