    public class HttpAjaxRequestAttribute : ActionMethodSelectorAttribute
    {
        public override bool IsValidForRequest(ControllerContext controllerContext, System.Reflection.MethodInfo methodInfo)
        {
            if (!controllerContext.HttpContext.Request.IsAjaxRequest())
            {
                throw new Exception("This action " + methodInfo.Name + " can only be called via an Ajax request");
            }
            return true;
        }
    }
