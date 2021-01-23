    // CONTROLLER
    [HttpGet]
    [XFrameOptionAllowAll]
    public ActionResult DoSomething()
    {
    	var viewModel = new DoSomethingViewModel();
    	return View(viewModel);
    }
    
    // ATTRIBUTE
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
    	filterContext.HttpContext.Response.Headers.Remove("X-Frame-Options");
    	filterContext.HttpContext.Response.AddHeader("X-Frame-Options", "AllowAll");
    
    	base.OnActionExecuting(filterContext);
    }
