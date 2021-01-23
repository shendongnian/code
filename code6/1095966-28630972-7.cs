    public class HomeController : BaseController<IHomeControllerValidator>
    {
        public HomeController(IHomeControllerValidator validator) : base(validator)
        {
        }
    }
