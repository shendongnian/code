    using Ninject.Infrastructure.Language; //needed for HasAttribute<T>
    //...
    Kernel.Bind(x => x.FromAssembliesMatching("PatentSpoiler*")
          .SelectAllClasses()
          .BindDefaultInterface()
          .Configure((cfg, type) =>
          {
              if (type.HasAttribute<BindAsASingletonAttribute>())
                  cfg.InSingletonScope();
              else if (type.HasAttribute<BindInRequestScopeAttribute>())
                  cfg.InRequestScope();
              else
                  cfg.InTransientScope();
          }));
