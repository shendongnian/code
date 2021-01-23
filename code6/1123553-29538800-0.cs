    public class RouteSetup {
      public static void Run(ILifetimeScope scope) {
        ISettings settings = scope.Resolve<ISettings>();
        // or 
        ISettings settings = DependencyResolver.Current.GetService<ISettings>();
        RouteTable.Routes.Localization(x => {
          x.AcceptedCultures = settings.AcceptedLanguages;
          x.DefaultCulture = settings.DefaultLanguage;
        });
        CultureSensitiveHttpModule.GetCultureFromHttpContextDelegate = context => { 
          return new CultureResolver().GetCulture(context); 
        };
      } // Run
    }
