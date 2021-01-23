    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using WebMatrix.WebData;
    namespace Coding.Lizards.Video.Manager.Web.Filters {
        public class CustomAuthorizeAttribute : AuthorizeAttribute {
            protected override bool AuthorizeCore(HttpContextBase httpContext) {
                if (WebSecurity.UserExists(httpContext.User.Identity.Name))
                    return true;
                return false;
            }
            protected override HttpValidationStatus OnCacheAuthorization(HttpContextBase httpContext) {
                if (WebSecurity.UserExists(httpContext.User.Identity.Name))
                    return HttpValidationStatus.Valid;
                return HttpValidationStatus.Invalid;
            }
        }
    }
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using WebMatrix.WebData;
    namespace Coding.Lizards.Video.Manager.Web.Filters {
        public class CustomAuthorizeAttribute : AuthorizeAttribute {
            protected override bool AuthorizeCore(HttpContextBase httpContext) {
                if (WebSecurity.UserExists(httpContext.User.Identity.Name))
                    return true;
                return false;
            }
            protected override HttpValidationStatus OnCacheAuthorization(HttpContextBase httpContext) {
                if (WebSecurity.UserExists(httpContext.User.Identity.Name))
                    return HttpValidationStatus.Valid;
                return HttpValidationStatus.Invalid;
            }
        }
    }
