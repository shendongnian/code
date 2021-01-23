    public class AllowFor : ActionFilterAttribute
    {
        private UserType userTypes = UserType.NotAuthenticated;
        public AllowFor(UserType userTypes)
        {
            this.userTypes = userTypes;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!(filterContext.Controller is ApplicationController))
                throw new Exception("AllowFor attribute is acceptable only for ApplicationController");
            var controller = (ApplicationController)filterContext.Controller;
            if (!userTypes.HasFlag(controller.CurrentUserType))
                filterContext.Result = new ViewResult
                {
                    ViewName = "AccessRestricted"
                };
            else
                base.OnActionExecuting(filterContext);
        }
    }
