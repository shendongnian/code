    builder.RegisterType<ProjectContextFactory>()
           .As<IProjectContextFactory>()
           .SingleInstance();
    builder.Register(c => c.Resolve<IProjectContextFactory>().GetContext())
           .As<ProjectContext>()
           .InstancePerRequest();
