    public interface IControllerFactory
    {
        TController CreateControllerAndView<TController>()
             where TController : Controller;
    }
    public class ControllerFactory
    {
        // actual provider
        private static IControllerFactory _provider;
        
        // factory method
        public static TController
            CreateControllerAndView<TController>() where T : Controller
        {
            return _provider.CreateController<TController>();
        }
        public static void SetProvider( IControllerFactory provider )
        {
            _provider = provider;
        }
    }
