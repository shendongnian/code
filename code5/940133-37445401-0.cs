        [Authorize()]
        [Secure(Roles = "Contact/Index")]
        public ActionResult Index()
        {
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //Get the user permissions from the Session. 
            //Using it every time that I get the controller and the action
        }
