    public static T Resolve<T>()
    {
        T resolved;
        //if (Container.IsRegistered<T>()) 
        try{
          resolved = Container.Resolve<T>();
        }
        catch(Exception){
          resolved = default(T);
        }
        return resolved;
    }
