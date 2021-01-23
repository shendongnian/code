    public class DomainViolationFilter : ExceptionFilterAttribute
        {
            public override void OnException(ExceptionContext context)
            {
                switch (context.Exception)
                {
                    case EntityNotFoundException e:
                        JsonResult toReturn = new JsonResult(e);
                        toReturn.StatusCode = 404;
                        context.Result = toReturn;
                        return;
                }
            }
        }
