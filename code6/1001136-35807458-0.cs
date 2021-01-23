    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using System.Web;
    
    namespace Owin
    {
        using AppFunc = Func<IDictionary<string, object>, Task>;
    
        public static class DynamicFileExtension
        {    
            /// <summary>
            /// ONLY use during development
            /// </summary>
            public static void UseDynamicFiles(this IAppBuilder app, string baseDirectory)
            {
                app.Use(new Func<AppFunc, AppFunc>(next => (async context =>
                {
                    var method = (string) context["owin.RequestMethod"];
                    var requestpath = (string) context["owin.RequestPath"];
                    var scheme = (string) context["owin.RequestScheme"];
                    var response = (Stream) context["owin.ResponseBody"];
                    var responseHeader = (Dictionary<string, string[]>) context["owin.ResponseHeaders"];
                   
                    if (method == "GET" && scheme == "http")
                    {
                        var fullpath = baseDirectory + requestpath;
                        // block logic...     
                        if (File.Exists(fullpath))
                        {
                            using (var file = File.OpenRead(fullpath))
                            {
                                await file.CopyToAsync(response);
                            }
    
                            var mime = MimeMapping.GetMimeMapping(fullpath);
    
                            responseHeader.Add("Content-Type", new[] {mime});
    
                            return;
                        }
                    }
    
                    await next.Invoke(context);
                })));
            }
        }
    } 
