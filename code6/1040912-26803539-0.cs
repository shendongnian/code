GetType().GetTypeInfo()
    public void Register(IResolver resolver)
    {
       foreach (Type classType in resolver.GetType().GetTypeInfo().Assembly.GetExportedTypes())
       {
          // Register the class type with the ioc container
       }
    }
