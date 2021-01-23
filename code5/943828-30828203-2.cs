    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.Owin;
    namespace MyWebApp.Web.AppCode.MiddlewareOwin
    {
        public class WebApiAuthInfoMiddleware : OwinMiddleware
        {
            public WebApiAuthInfoMiddleware(OwinMiddleware next)
                : base(next)
            {
            }
            public override Task Invoke(IOwinContext context)
            {
                var userId = context.Request.User.Identity.GetUserId<int>();
                context.Environment[MyWebApp.Constants.Constant.WebApiCurrentUserId] = userId;
                return Next.Invoke(context);
            }
        }
    }
