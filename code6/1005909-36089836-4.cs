    public class BarService : IBarService
        {
            private readonly Func<Owned<IEntityContext>> _entityContext;
    
            public BarService(Func<Owned<IEntityContext>> entityContext)
            {
                _entityContext = entityContext;
            }
    
            public void SaveFoo(string name)
            {
                using (var context = _entityContext())
                {
                    context.SaveChanges();
                }
            }
    
            public void SaveBar(string otherName)
            {
                using (var context = _entityContext())
                {
                    context.SaveChanges();
                }
            }
        }
     
