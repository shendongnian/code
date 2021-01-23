    public class WatchInstaller : IWindsorInstaller
    {
          public void Install(IWindsorContainer container, IConfigurationStore store)
          {
              container.Register(
                  Component.For<IWatch>().ImplementedBy<Watch>()
              );
          }
    }
