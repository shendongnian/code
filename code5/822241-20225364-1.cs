    public class ModelStateValidFilterAttribute : System.Web.Http.Filters.ActionFilterAttribute
    {
        /// <summary>
        /// Before the action method is invoked, check to see if the model is
        /// valid.
        /// </summary>
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext p_context)
        {
            if (!p_context.ModelState.IsValid)
            {
                List<ErrorPart> errorParts = new List<ErrorPart>();
                foreach (var modelState in p_context.ModelState)
                {
                    foreach (var error in modelState.Value.Errors)
                    {
                        String message = "The request is not valid; perhaps it is not well-formed.";
                        if (error.Exception != null)
                        {
                            message = error.Exception.Message;
                        }
                        else if (!String.IsNullOrWhiteSpace(error.ErrorMessage))
                        {
                            message = error.ErrorMessage;
                        }
                        errorParts.Add(
                            new ErrorPart
                            {
                                ErrorMessage = message
                              , Property = modelState.Key
                            }
                        );
                    }
                }
                throw new HttpResponseException(
                    p_context.Request.CreateResponse<Object>(
                        HttpStatusCode.BadRequest
                      , new { Errors = errorParts }
                    )
                );
            }
            else
            {
                base.OnActionExecuting(p_context);
            }
        }
    }
