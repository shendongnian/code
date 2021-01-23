    /// <summary>
    /// This interface is implemented by all repositories to ensure implementation of fixed methods.
    /// </summary>
    /// <typeparam name="TEntity">Main Entity type this repository works on</typeparam>
    /// <typeparam name="TKey">Primary key type of the entity</typeparam>
    public interface IRepository<TKey, TEntity> : IRepository where TEntity : class, IEntity<TKey>
    {
        /// <summary>
        /// Inserts a new entity.
        /// </summary>
        /// <param name="entity">Entity to insert</param>
        TEntity Insert(TEntity entity);
    
        /// <summary>
        /// Inserts multiple entities.
        /// </summary>
        /// <param name="entities">Entities to insert</param>
        IEnumerable<TEntity> Insert(IEnumerable<TEntity> entities);
    
        /// <summary>
        /// Updates an existing entity.
        /// </summary>
        /// <param name="entity">Entity</param>
        TEntity Update(TEntity entity);
    
        /// <summary>
        /// Updates or saves an entity
        /// </summary>
        /// <param name="entity">Entity</param>
        TEntity SaveOrUpdate(TEntity entity);
    
        /// <summary>
        /// Deletes an entity.
        /// </summary>
        /// <param name="id">Id of the entity</param>
        bool Delete(TKey id);
    
        /// <summary>
        /// Deletes an entity.
        /// </summary>
        /// <param name="entity">Entity to be deleted</param>
        bool Delete(TEntity entity);
    
        /// <summary>
        /// Deletes an entity.
        /// </summary>
        /// <param name="entities">Entities to be deleted</param>
        bool Delete(IEnumerable<TEntity> entities);
    
        /// <summary>
        /// Used to get an IQueryable that is used to retrieve entities from entire table.
        /// </summary>
        /// <returns>IQueryable to be used to select entities from database</returns>
        IQueryable<TEntity> All();
    
        /// <summary>
        /// Gets an entity.
        /// </summary>
        /// <param name="expression">LINQ expression used to evaluate and find an entity</param>
        /// <returns>Entity</returns>
        TEntity FindBy(Expression<Func<TEntity, bool>> expression);
    
        /// <summary>
        /// Used to get an IQueryable that is used to retrieve entities from evaluated LINQ expression.
        /// </summary>
        /// <param name="expression">LINQ expression used to evaluate and find entities</param>
        /// <returns>IQueryable to be used to select entities from database</returns>
        IQueryable<TEntity> FilterBy(Expression<Func<TEntity, bool>> expression);
    
        /// <summary>
        /// Gets an entity.
        /// </summary>
        /// <param name="id">Primary key of the entity to get</param>
        /// <returns>Entity</returns>
        TEntity FindBy(TKey id);
    }
