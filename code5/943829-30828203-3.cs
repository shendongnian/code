    using System;
    using Owin;
    namespace MyWebApp.Web.AppCode.MiddlewareOwin
    {
        public static class OwinAppBuilderExtensions
        {
            public static IAppBuilder UseWebApiAuthInfo(this IAppBuilder @this)
            {
                if (@this == null)
                {
                    throw new ArgumentNullException("app");
                }
                @this.Use(typeof(WebApiAuthInfoMiddleware));
                return @this;
            }
        }
    }
