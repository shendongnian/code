    public class MyController : Controller
    {
      private IMyService _myService;
      
      protected override void OnActionExecuting(ActionExecutingContext ctx)
	  {
		base.OnActionExecuting(ctx);
		int type;
		var routeValue = ControllerContext.RouteData.Values["type"];
	
		Discriminator type;
			
		if(!Enum.TryParse<Discriminator>(routeValue.ToString(), out type))
		{
			//set a default value
			type = Discriminator.Animal;
		}
	
		_myService = NInjectKernel.Instance.GetService<IMyService>("type", type);
	  }
      public ActionResult Index(id)
      {
        _myService.GetById(id);
        return View(model);
      }
    }
	
