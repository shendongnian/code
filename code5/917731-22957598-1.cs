    public static class NinjectHelper
    {
     public static T Resolve<T>()
     {
      IKernel kernel = new StandardKernel();
      kernel.Load(Assembly.GetExecutingAssembly());
      return kernel.Get<T>();
     }
    }
