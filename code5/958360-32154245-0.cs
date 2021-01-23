    public class ManagersAccessPoint
    {
      private Dictionary<Type, object> _items : Dictionary<Type, object>();
    
      public void Register<TEntity>(AbstractManager<TEntity> manager)
      {
          _items[typeof(TEntity)] = manager;
      }
    
      public AbstractManager<TEntity> Get<TEntity>()
      {
          return (AbstractManager<TEntity>)_items[typeof(TEntity)];
      }
    }
