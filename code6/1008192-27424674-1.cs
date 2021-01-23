    public class MyViewModel : Screen
    {
         IRegistrationService _registrationService;
         IEnumerable<IResolver> _resolver;
         public MyViewModel(IRegistrationService registrationService, IEnumerable<IResolver> resolver)
         {
             _registrationService = registrationService;
             _resolver = resolver;
         }
         public void ChangeToMode()
         {
               foreach(var resl in _resolver)
               {
                    if(resl.ShouldRegister(.. some parameter..))
                    {
                        _registrationService.Register(resl);
                        return;
                    }
               }
         }
    }
