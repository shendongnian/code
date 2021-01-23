    public class BaseReadController : Controller
    {
        protected IMediator Mediator { get; set; }
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
            ActionInvoker = new ReadControllerActionInvoker(Mediator);
        }
    }
