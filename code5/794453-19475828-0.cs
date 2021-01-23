    protected override void Initialize(System.Web.Http.Controllers.HttpControllerContext controllerContext)
    { 
       //Your Logic
       throw new HttpResponseException(controllerContext.Request.CreateErrorResponse(System.Net.HttpStatusCode.Unauthorized, "error"));
       base.Initialize(controllerContext);
    }
