    // Assembly Microsoft.Owin.Host.SystemWeb.dll, v3.1.0.0
    
    using Microsoft.Owin;
    using System;
    using System.Runtime.CompilerServices;
    namespace System.Web
    {
        public static class HttpContextExtensions
        {
            public static IOwinContext GetOwinContext(this HttpContext context);
            public static IOwinContext GetOwinContext(this HttpRequest request);
        }
    }
