    public abstract class ModelValidationFilter : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            //Modify the values in the current filterContext.Result instead of replacing it with a new instance
            var jsonResult = filterContext.Result as JsonResult;
            if(jsonResult == null) return;
            //possibly replace Data only under certain conditions
            jsonResult.Data = new { modelState = SerializeErrors(modelState) };
        }
    }
