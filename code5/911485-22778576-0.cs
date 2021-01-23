    public abstract class ApiBaseController : ApiController
    {
        public ApiBaseController(IUow uow)
        {
            Uow = uow;
        }
        protected IUow Uow { get; private set; }
    }
    public class ContentStatusController : ApiBaseController
    {
        public ContentStatusController(IUow uow) : base(uow) //<-- This is needed
        {
        }
    }
