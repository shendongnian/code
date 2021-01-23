    internal class ThrowModelStateErrorsActionInvoker : ApiControllerActionInvoker
    {
        public override Task<HttpResponseMessage> InvokeActionAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            foreach (var error in actionContext.ModelState.SelectMany(kvp => kvp.Value.Errors))
            {
                var exception = error.Exception ?? new ArgumentException(error.ErrorMessage);
                //invoke global exception handling
            }
            return base.InvokeActionAsync(actionContext, cancellationToken);
        }
    }
