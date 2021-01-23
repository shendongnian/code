    public class CustomerDataModule : Autofac.Module
    {
      protected override void Load(ContainerBuilder builder)
      {
        builder.RegisterType<CustomerDataMapperProfile>().As<Profile>();
      }
    }
    public class UserAuthenticationModule : Autofac.Module
    {
      protected override void Load(ContainerBuilder builder)
      {
        builder.RegisterType<UserAuthenticationMapperProfile>().As<Profile>();
      }
    }
