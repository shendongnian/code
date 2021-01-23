    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Net;
    namespace CustomProject
    {
        public class CustomAuthorizeAttribute : AuthorizeAttribute
        {
            protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
            {
                System.Web.Routing.RouteValueDictionary rd;
                if (filterContext.HttpContext.User.Identity.IsAuthenticated)
                {
                    switch (filterContext.HttpContext.Response.StatusCode)
                    {
                    case (int)HttpStatusCode.Unauthorized:
                        {
                            rd = new System.Web.Routing.RouteValueDictionary(new { action = "NotAuthorized", controller = "Error" });
                            break;
                        }
                    default:
                        {
                            rd = new System.Web.Routing.RouteValueDictionary(new { action = "Index", controller = "Error" });
                            break;
                        }
                    }                
                }
                else
                {
                    //user is not authenticated
                    rd = new System.Web.Routing.RouteValueDictionary(new { action = "Login", controller = "Account" });
                }
                filterContext.Result = new RedirectToRouteResult(rd);
            }
        }
    }
