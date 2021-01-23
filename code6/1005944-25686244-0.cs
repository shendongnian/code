    public static T Resolve<T>()
    {
        T resolved = default(T);
        //if (Container.IsRegistered<T>()) 
        try{
          resolved = Container.Resolve<T>();
        }
        catch(Exception exception){
          resolved = null;
        }
        return resolved;
    }
