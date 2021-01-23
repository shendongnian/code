    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using WebMatrix.WebData;
    namespace Coding.Lizards.Video.Manager.Web.Filters {
        public static class RequestExtensions {
            public static bool IsAuthenticated(this HttpRequestBase request) {
                if (WebSecurity.UserExists(request.RequestContext.HttpContext.User.Identity.Name))
                    return true;
                return false;
            }
        }
    }
