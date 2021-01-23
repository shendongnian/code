    namespace Foo 
    {
        using AppFunc = Func<IDictionary<string, object>, Task>;
    
        public class Html5ModeMiddleware
        {
            private readonly Html5ModeOptions m_Options;
            private readonly StaticFileMiddleware m_InnerMiddleware;
            private readonly StaticFileMiddleware m_EntryPointAwareInnerMiddleware;
    
            public Html5ModeMiddleware(AppFunc next, Html5ModeOptions options)
            {
                if (next == null) throw new ArgumentNullException(nameof(next));
                if (options == null) throw new ArgumentNullException(nameof(options));
    
                m_Options = options;
                m_InnerMiddleware = new StaticFileMiddleware(next, options.FileServerOptions.StaticFileOptions);
                m_EntryPointAwareInnerMiddleware = new StaticFileMiddleware((environment) =>
                {
                    var context = new OwinContext(environment);
                    context.Request.Path = m_Options.EntryPath;
                    return m_InnerMiddleware.Invoke(environment);
    
                }, options.FileServerOptions.StaticFileOptions);
            }
    
            public Task Invoke(IDictionary<string, object> environment) => 
                m_EntryPointAwareInnerMiddleware.Invoke(environment);
        }
    }
