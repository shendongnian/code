    public class CommonRegistrations : Module
    {
      protected override void Load(ContainerBuilder builder)
      {
        // Put your common registrations here.
        builder.RegisterType<Common>().As<ICommon>();
      }
    }
