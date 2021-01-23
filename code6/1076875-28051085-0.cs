    [Serializable]
    public class RedirectOnExceptionAttribute : OnExceptionAspect
    {
        public string ToAction { get; set; }
        public override void OnException(MethodExecutionArgs args)
        {
            // NotifyUser(args.Exception.Message);
            args.FlowBehavior = FlowBehavior.Return;
            object controller = ((ControllerBase) args.Instance).ControllerContext.RouteData.Values["controller"];
            args.ReturnValue = new RedirectToRouteResult(
                new RouteValueDictionary
                    {
                        {"action", this.ToAction},
                        {"controller", controller}
                    });
        }
    }
