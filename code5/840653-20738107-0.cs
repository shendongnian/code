     container.ResolveUnregisteredType += (s, e) =>
     {
          Type type = e.UnregisteredServiceType;
          if (type.IsGenericType && 
              type.GetGenericTypeDefinition() == typeof(IRepository<>))
          {
               var args = type.GetGenericArguments();
          
               e.Register(() => RepositoryFactory.GetInstance(args[0], configuration));
          }
     };
