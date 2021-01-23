        public class NHibernateRepositoryModule : NinjectModule
        {
            public override void Load()
            {
                this.Bind<IProductRepository>().To<NHibernateProductRepository>();
                // Bind whatever else you need when working with NHibernate
            }
        }
        // NinjectWebCommon
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Load<EfRepositoryModule>();
        }
