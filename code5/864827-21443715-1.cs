    public class RepositoryInstaller : IWindsorInstaller
    {
        #region IWindsorInstaller Members
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly().BasedOn<Repository>().Configure(c=>c.Named(c.Implementation.Name)));
            container.Register(
                Component.For<RepositoryFactorySelector, ITypedFactoryComponentSelector>().LifestyleSingleton(),
                Component.For<IRepositoryFactory>().AsFactory(c => c.SelectedWith<RepositoryFactorySelector>()));
        }
        #endregion
    }
