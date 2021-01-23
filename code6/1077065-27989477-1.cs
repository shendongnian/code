    public class AdministrationAreaRegistration : AreaRegistration
    {
         public override string AreaName{
              get{ "Administration"}
         }
    
         public override void RegisterArea(AreaRegistrationContext context){
              context.MapRoute(
                   "Administration_default",
                   "Administration/{controller}/{action}/{id}",
                   new { action = "Index", id = UrlParameter.Optional},
                   new [] { "YourControllerNamespace" }
              );
         }
    
    
    }
