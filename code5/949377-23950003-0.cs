    public class GetBindValueFilterAttribute : ActionFilterAttribute
    {
        public string KeysString { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            foreach (var inputParameter in filterContext.ActionDescriptor.GetParameters())
            {
                var bindAttribute = inputParameter.GetCustomAttributes(typeof(BindAttribute), false)
                                                  .Cast<BindAttribute>()
                                                  .FirstOrDefault();
                if (bindAttribute != null) this.KeysString += " " + bindAttribute.Include;
            }
            
        }
    }
