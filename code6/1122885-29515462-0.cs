    List<Registration> cacheableComponents = new List<Registration>();
    foreach (var reg in serviceRegistrations)
    {
         Lifestyle lifeStyle;
         if (lifeStyles.TryGetValue(reg.Implementation, out lifeStyle) == false)
         {
                 lifeStyle = Lifestyle.Singleton;
         }
    
         Registration registration = null;
         if (lifeStyle == Lifestyle.Singleton)
         {
             registration = Lifestyle.Singleton.CreateRegistration(reg.Implementation, container);
         }
         else
         {
             registration = Lifestyle.Transient.CreateRegistration(reg.Implementation, container);
         }
    
         foreach (var service in reg.Services)
         {
           if (typeof(ICanRefreshCache) == service)
             {
                 cacheableComponents.Add(registration);
                 continue;
             }
    
              container.AddRegistration(service,registration);
         }
    }
    container.RegisterAll(typeof(ICanRefreshCache), cacheableComponents);
