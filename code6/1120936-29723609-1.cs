    public class Bootstrap {
      public void Register() {
         var container = new UnityContainer();
         container.RegisterType<IGenderService, GenderService>();
         container.RegisterType<Configuration>();
      }
    }
    internal sealed class Configuration:  {
      private IGenderService _genderService;
      public Configuration(IGenderService genderService) {
         _genderService = genderService;
      }
    }
    ...
    // resolving
    var config = container.Resolve<Configuration>();
 
    
