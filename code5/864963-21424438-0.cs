    container.Register(
       Classes.FromAssembly(Assembly.GetExecutingAssembly())
          .BasedOn<ICommon>()
          .LifestyleTransient()
          .Configure(component => component.Named(component.Implementation.FullName + "XYZ"))
