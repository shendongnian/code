    class MyClassHandler<TEntity, TStatus>
        where TEntity : IChangeStatus<TStatus>
    {
         public IEnumerable<TStatus> Statuses
         {
              get { return _entities.Select(entity => entity.Status); }
         }
    }
