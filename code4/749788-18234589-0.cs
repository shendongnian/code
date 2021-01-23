    public BaseController: Controller
    {
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            ViewBag.UserMenu = this.UserIntranet.Login;
        }
    }
