    public static void RegisterTypes(IUnityContainer container)
    {
      var useCache = bool.Parse(ConfigurationManager.AppSettings["useCache"]);
      if (useCache) { 
        // named, this is not the default
        container.RegisterType<ICookieOven,CookieOven>("oven");
        // this one is not named and is the default
        container.RegisterType<ICookieOven,CachedCookieOven>(new InjectionConstructor(
          container.Resolve<ICookieOven>("oven")); 
      } else {
        // notice it is not named, it is the default
        container.RegisterType<ICookieOven,CookieOven>();
      }
    }
