        public class EfRepositoryModule : NinjectModule
        {
            public override void Load()
            {
                this.Bind<IProductRepository>().To<EfProductRepository>();
                this.Bind<ExDbContext>().ToSelf().InRequestScope();
            }
        }
