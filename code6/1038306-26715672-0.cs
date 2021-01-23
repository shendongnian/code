    public class SomeFacade<TRepository> where TRepository : class, IRepository
    {
            public void Add<TEntity>(TEntity entity) where TEntity : AbstractEntity
            {
                try
                {
                    if (entity is IInitialiazableEntity<IRepository>)
                        (entity as IInitialiazableEntity<IRepository>).Initialize(this.Repository);
                }
                catch (Exception ex)
                {
                    this.Logger.Error(ex);
                }
            }
    }
