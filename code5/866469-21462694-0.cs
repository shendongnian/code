    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Reflection;
    
    
    namespace Web {
    
    
        public class SessionExpireFilterAttribute : ActionFilterAttribute {
    
    
            public override void OnActionExecuting( ActionExecutingContext filterContext ) {
                HttpContext ctx = HttpContext.Current;
    
    
                // check if session is supported
                if ( ctx.Session != null ) {
    
    
                    // check if a new session id was generated
                    if ( ctx.Session.IsNewSession ) {
    
    
                        // If it says it is a new session, but an existing cookie exists, then it must
                        // have timed out
                        string sessionCookie = ctx.Request.Headers[ "Cookie" ];
                        if ( ( null != sessionCookie ) && ( sessionCookie.IndexOf ( "ASP.NET_SessionId" ) >= 0 ) ) {
    
    
                            ctx.Response.Redirect ( "~/Home/Login" );
                        }
                    }
                }
    
    
                base.OnActionExecuting ( filterContext );
            }
        }
    }
    
   
