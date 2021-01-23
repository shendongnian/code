    public static AutofacDependencyResolver Current
    {
      get
      {
        return DependencyResolver.Current.GetService<AutofacDependencyResolver>();
      }
    }
