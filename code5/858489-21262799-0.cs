    internal class ThrowModelStateErrorsActionInvoker : ApiControllerActionInvoker
    {
        public override Task<HttpResponseMessage> InvokeActionAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            foreach (var error in actionContext.ModelState.SelectMany(kvp => kvp.Value.Errors))
            {
                throw error.Exception ?? new ArgumentException(error.ErrorMessage);
            }
            return base.InvokeActionAsync(actionContext, cancellationToken);
        }
    }
