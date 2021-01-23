    public class Test
    {
        public void Run()
        {
            IUnityContainer myContainer = new UnityContainer();
            myContainer.RegisterType<IRepository, NHibernateRepository>();
            var ctx = myContainer.Resolve<ADataObjectContext>();
            var obj = ctx.Query().Where(p => p.Id == 2);
        }
    }
