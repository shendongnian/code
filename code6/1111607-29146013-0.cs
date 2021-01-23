    public class MyRegistry : Registry
    {
        public MyRegistry()
        {
            this.For<IUnitOfWork>().Use(new UnitOfWork("Connection1"));
            this.For<IDatabase2Service>().Use<Database2Service>().Ctor<IUnitOfWork>().Is(new UnitOfWork("Connection2"));
        }
    }
    
