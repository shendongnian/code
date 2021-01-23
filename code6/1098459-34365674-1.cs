    public abstract class WebApiControllerBase : ApiController {
        [Route("{*actionName}")]
        [AcceptVerbs("GET", "POST", "PUT", "DELETE")]//Include what ever methods you want to handle
        [AllowAnonymous]//So I can use it on authenticated controllers
        [ApiExplorerSettings(IgnoreApi = true)]//To hide this method from helpers
        public virtual HttpResponseMessage HandleUnknownAction(string actionName) {
            var status = HttpStatusCode.NotFound;
            //This is custom code to create my response content
            //....
            var message = status.ToString().FormatCamelCase();
            var content = DependencyService
                .Get<IResponseEnvelopeFactory>()
                .CreateWithOnlyMetadata(status, message);
            //....
            return Request.CreateResponse(status, content);
        }
    }
