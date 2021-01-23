    public class CustomHandleErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            //When already handled, do nothing
            if (context.ExceptionHandled)
                return;
            //Run the base functionality
            base.OnException(context);
            //If the base functionality didnt handle the exception, then exit (as the exception is not of the type this filter should handle)
            if (!context.ExceptionHandled) return;
            //Set a view as the result           
            context.Result = GetViewResult(context);            
        }
        private ViewResult GetViewResult(ExceptionContext context)
        {
            //The model of the error view (YourModelType) will inherit from the base view model required in the layout
            YourModelType model = new YourModelType(context.Exception, ...);
            var result = new ViewResult
            {
                ViewName = View,
                ViewData = new ViewDataDictionary<YourModelType>(model),
                TempData = context.Controller.TempData
            };
            return result;
        }
    }
