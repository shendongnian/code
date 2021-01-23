    public class MyFilter : IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            //That will give you "HomeController"
            var controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            //You can remove the "Controller" part, by replacing it with an empty string, like:
            var justTheController = controllerName.Replace("Controller", string.Empty);
        }
    }
