    public class ResponseWrapAttribute : ActionFilterAttribute
    {
        
        public override void OnActionExecuted(HttpActionExecutedContext filterContext)
        {
            if (filterContext.Exception == null)
            {
                var content = filterContext.Response.Content as ObjectContent;
                var response = ResponseDTO.CreateDynamicResponse(content.Value);
                ((ObjectContent)filterContext.Response.Content).Value = response;
               
            }
            base.OnActionExecuted(filterContext);
        }
       
    }
