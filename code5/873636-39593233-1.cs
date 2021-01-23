    public class HomeController : Controller {
      private IFactory<IService> m_Factory;
      public HomeController(IFactory<IService> factory) {
        m_Factory = factory;
      } 
      private void FooBar() {
        var service = m_Factory.Retrieve(this.HttpContext.Uri.Host);
        var hello = service.Hello;
      }   
    }
