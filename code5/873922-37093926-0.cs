    public class ModelStateValidationFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting( ActionExecutingContext context )
        {
            if ( context.HttpContext.Request.Method == "POST" && !context.ModelState.IsValid )
                context.Result = new BadRequestObjectResult( context.ModelState );
        }
    }
