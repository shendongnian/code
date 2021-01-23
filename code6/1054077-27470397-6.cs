    public class MaxLengthActionFilter : IActionFilter
    {
        public readonly IConfigProvider configProvider;
        public MaxLengthActionFilter(IConfigProvider configProvider)
        {
            if (configProvider == null)
                throw new ArgumentNullException("configProvider");
            this.configProvider = configProvider;
        }
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var attribute = this.GetMaxLengthAttribute(filterContext.ActionDescriptor);
            if (attribute != null)
            {
                var maxLength = attribute.MaxLength;
                // Execute your behavior here, and use the configProvider as needed
            }
        }
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var attribute = this.GetMaxLengthAttribute(filterContext.ActionDescriptor);
            if (attribute != null)
            {
                var maxLength = attribute.MaxLength;
                // Execute your behavior here, and use the configProvider as needed
            }
        }
        public MaxLengthAttribute GetMaxLengthAttribute(ActionDescriptor actionDescriptor)
        {
            MaxLengthAttribute result = null;
            // Check if the attribute exists on the controller
            result = (MaxLengthAttribute)actionDescriptor
                .ControllerDescriptor
                .GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .SingleOrDefault();
            if (result != null)
            {
                return result;
            }
            // NOTE: You might need some additional logic to determine 
            // which attribute applies (or both apply)
            // Check if the attribute exists on the action method
            result = (MaxLengthAttribute)actionDescriptor
                .GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .SingleOrDefault();
            
            return result;
        }
    }
