    public class TrackUser : ActionFilterAttribute, IActionFilter
    {
        public string BaseUrl { get; set; }
        public string Service { get; set; }
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Some logic to execute
            var controller = filterContext.Controller as ParentController;
            if (controller != null)
            {
                var url = controller.GetUrl();
                // Use it here
            }
        }
    }
