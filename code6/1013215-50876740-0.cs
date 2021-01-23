    public class ForbiddenObjectResult : ObjectResult
    {
        public ForbiddenObjectResult(object value)
                : base(value)
        {
            StatusCode = StatusCodes.Status403Forbidden;
        }
    }
    ...
    filterContext.Result = new ForbiddenObjectResult(filterContext.ModelState);
