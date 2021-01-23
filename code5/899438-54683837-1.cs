     protected override bool AuthorizeCore(System.Web.Http.Controllers.HttpActionContext actionContext)
                {
                    BaseApiController baseApi = actionContext.ControllerContext.Controller as BaseApiController;
                    baseApi.Property = 10;
                }
