    public class HomeController : Controller
    {
        public HomeController(IOrderRepository orderRepository, IUserRepository userRepository, ITokenRepository tokenRepository)
        {
            Debug.WriteLine("Order repository context: {0}, User repository context:{1}", orderRepository.UnitOfWork.DbContext.Name, userRepository.UnitOfWork.DbContext.Name);
            Debug.WriteLine("Order repository context: {0}, User repository context:{1}", orderRepository.UnitOfWork.DbContext.GetType().Name, userRepository.UnitOfWork.DbContext.GetType().Name);
            Debug.Assert(orderRepository.UnitOfWork != userRepository.UnitOfWork);
            Debug.Assert(userRepository.UnitOfWork == tokenRepository.UnitOfWork);
        }
        public ActionResult Index()
        {
            return View();
        }
    }
