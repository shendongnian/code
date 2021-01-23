        using System;
        using System.Linq;
        using System.Web;
        using System.Web.Mvc;
        using System.Web.Routing;
        using System.Web.Security;
        using PortalAPI.SPModels;
        using SICommon.Enums;
        using SICommon.LoggingOperations;
        
        namespace SupplierPortal.Security {
        	public class AuthorizedUser : AuthorizeAttribute {
        		public bool IsAuthorized { get; set; }
        		
        		protected override bool AuthorizeCore(HttpContextBase httpContext) {
        
        			if (Authenticated())
        			  return this.IsAuthorized = true;
        		}
        
                protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext) {
        			if (filterContext.HttpContext.Request.IsAjaxRequest()) {
        				filterContext.HttpContext.Response.StatusCode = 403;
        				filterContext.Result = new JsonResult {
        					Data = new {
        						Error = "SessionTimeOut"
        					},
        					JsonRequestBehavior = JsonRequestBehavior.AllowGet
        				};
        				filterContext.HttpContext.Response.End();
        			} else {
        				filterContext.Result = new RedirectToRouteResult(
        					new RouteValueDictionary(
        						new {
        							controller = "Account",
        							action = "Login"
        						}
        					)
        				);
        			}
        			base.HandleUnauthorizedRequest(filterContext);
        		}
        	}
        }
        
        [AuthorizedUser(IsAuthorized = true)]
        public class myformclass(){
            //some code in here for form
        }
