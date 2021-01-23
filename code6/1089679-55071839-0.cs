    public class RouteInfoController : Controller
    {
		// for accessing conventional routes...
	    private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;
		public RouteInfoController(
			IActionDescriptorCollectionProvider actionDescriptorCollectionProvider)
	    {
			_actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
	    }
        public IActionResult Index()
        {
			StringBuilder sb = new StringBuilder();
	        foreach (ActionDescriptor ad in _actionDescriptorCollectionProvider.ActionDescriptors.Items)
	        {
		        var action = Url.Action(new UrlActionContext()
		        {
			        Action = ad.RouteValues["action"],
			        Controller = ad.RouteValues["controller"],
					Values = ad.RouteValues
				});
		        sb.AppendLine(action).AppendLine().AppendLine();
	        }
			return Ok(sb.ToString());
		}
