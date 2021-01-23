    public class AutoMapperModule : Autofac.Module
    {
      protected override void Load(ContainerBuilder builder)
      {
        // Register the common thing once, not in each module.
        builder.RegisterType<MappingEngine>().As<IMappingEngine>();
        // Here's where you dynamically get all the registered profiles
        // and add them at the same time to the config store.
        builder.Register(ctx =>
          {
            var profiles = ctx.Resolve<IEnumerable<Profile>>();
            var configStore = new ConfigurationStore
                (new TypeMapFactory(), MapperRegistry.AllMappers());
            foreach(var profile in profiles)
            {
              configStore.AddProfile(profile);
            }
            return configStore;
          })
          .AsImplementedInterfaces()
          .SingleInstance();
      }
    }
