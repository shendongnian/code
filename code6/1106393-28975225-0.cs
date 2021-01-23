    public class ControllersInstallers : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                                .BasedOn<IHttpController>()
                                .LifestylePerWebRequest());
        }
    }
