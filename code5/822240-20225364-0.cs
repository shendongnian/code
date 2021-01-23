    /// <summary>
    /// Throws an <c>HttpResponseException</c> if the model state is not valid;
    /// with no validation attributes in the model, this will occur when the
    /// input is not well-formed.
    /// </summary>
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
                throw new HttpResponseException(
                    new HttpResponseMessage
                    {
                        Content = new StringContent("The posted data is not valid; perhaps it is not well-formed.")
                      , ReasonPhrase = "Exception"
                      , StatusCode = HttpStatusCode.InternalServerError
                    }
                );
            }
            else
            {
                base.OnActionExecuting(p_context);
            }
        }
    }
