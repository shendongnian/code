     protected override bool AuthorizeCore(System.Web.Http.Controllers.HttpActionContext actionContext)
                {
                    BaseApiController Controller = actionContext.ControllerContext.Controller as BaseApiController;
                    baseApi.Property = 10;
                }
