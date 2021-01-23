    public class BarService : IBarService
    {
        private readonly IEntityContextFactory _entityContextFactory;
        public BarService(IEntityContextFactory entityContextFactory)
        {
            _entityContextFactory = entityContextFactory;
        }
        public void SaveFoo(string name)
        {
            using (IEntityContext entityContext = _entityContextFactory.CreateEntityContext())
            {
                // some EF stuff here
                entityContext.SaveChanges();
            }
        }
        public void SaveBar(string otherName)
        {
            using (IEntityContext entityContext = _entityContextFactory.CreateEntityContext())
            {
                // some EF stuff here
                _entityContext.SaveChanges();
            }
        }
    }
