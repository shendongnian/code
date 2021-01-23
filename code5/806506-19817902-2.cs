    public class HasAssignedAcccessActionInvoker : ControllerActionInvoker
    {
        protected override AuthorizationContext InvokeAuthorizationFilters(ControllerContext controllerContext, IList<IAuthorizationFilter> filters, ActionDescriptor actionDescriptor)
        {
            AuthorizationContext authCtx = new AuthorizationContext(controllerContext, actionDescriptor);
            /*
             * If any of the filters are RequiresAssignedAccess, default this to false.  One of them must authorize the user.
             */
            bool hasAccess = !filters.Any(f => f is RequiresAssignedAccess);
            foreach (IAuthorizationFilter current in filters)
            {
                /*
                 * This sets authorizationContext.Result, usually to an instance of HttpUnauthorizedResult
                 */
                current.OnAuthorization(authCtx);
                if (current is RequiresAssignedAccess)
                {
                    if (authCtx.Result == null)
                    {
                        hasAccess = true;
                    }
                    else if (authCtx.Result is HttpUnauthorizedResult)
                    {
                        authCtx.Result = null;
                    }
                    continue;
                }
                if (authCtx.Result != null)
                    break;
            }
            if (!hasAccess && authCtx.Result == null)
                authCtx.Result = new HttpUnauthorizedResult();
            return authCtx;
        }
    }
