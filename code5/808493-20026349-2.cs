    public class BaseController : Controller
    {
        private readonly IMediator mediator;
        public BaseController():this(new Mediator())
        {
        }
        public BaseController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public IMediator GetMediator()
        {
            return mediator;
        }
    }
