    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
        
    [assembly: WebActivatorEx.PreApplicationStartMethod(typeof(AppStart), "PreStart")]
    [assembly: WebActivatorEx.PostApplicationStartMethod(typeof(AppStart), "Start")]
    namespace EmbeddedPages
    {
      public static class AppStart
      {
          private static bool PreStartFired = false;
          public static void PreStart()
          {
              if (!PreStartFired)
              {
                  PreStartFired = true;
                  DynamicModuleUtility.RegisterModule(typeof(UrlRoutingModule));
              }
          }
      }
    }
