    public class HomeController : Controller
    {
        IUserNameRetriever _currentUserNameRetriever;
        public HomeController(IIndex<AuthenticatedStatusEnum, IUserNameRetriever> userNameRetrievers)
        {
            _currentUserNameRetriever = _userNameRetrievers[AuthenticatedStatus];
        }
        AuthenticatedStatusEnum AuthenticatedStatus
        {
            get
            {
                return System.Threading.Thread.CurrentPrincipal.Identity.IsAuthenticated ? AuthenticatedStatus.Authenticated : AuthenticatedStatus.Anonymous;
            }
        }
