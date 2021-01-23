    //AllowMultiple is false by default. This is only for illustration purposes.
    //Feel free to remove this since its already defined in ActionFilterAttribute
    public class NoCacheAttribute : ActionFilterAttribute
    {
        public bool Disable { get; set; }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            if (!Disable)
            {
                //do your thing
            }
            base.OnResultExecuted(filterContext);
        }
    }
	
