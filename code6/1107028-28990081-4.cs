    public class MyEntitiesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<MyEntities>().LifestylePerWebRequest().IsDefault(),
                               Component.For<MyEntities>().Named("MyEntitiesTransient").LifestyleTransient());
        }
    }
