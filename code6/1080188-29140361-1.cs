    /// <summary>
    /// This interface defines all properties and methods common to all Entity Creators.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IEntityCreator<TEntity>
        where TEntity : IEntity
    {
        #region Methods
        /// <summary>
        /// Create a new instance of <see cref="TEntity"/>
        /// </summary>
        /// <returns></returns>
        TEntity Create();
        #endregion
    }
    
    /// <summary>
    /// This interface defines all properties and methods common to all Entity Readers.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IEntityReader<TEntity>
       where TEntity : IEntity
    {
        #region Methods
        /// <summary>
        /// Get all entities in the data store.
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll();
        /// <summary>
        /// Find all entities that match the expression
        /// </summary>
        /// <param name="whereExpression">exprssion used to filter the results.</param>
        /// <returns></returns>
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> whereExpression);
        #endregion
    }
    /// <summary>
    /// This interface defines all properties and methods common to all Entity Updaters. 
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IEntityUpdater<TEntity>
        where TEntity : IEntity
    {
        #region Methods
        /// <summary>
        /// Save an entity in the data store
        /// </summary>
        /// <param name="entity">The entity to save</param>
        void Save(TEntity entity);
        #endregion
    }
    /// <summary>
    /// This interface defines all properties and methods common to all Entity removers.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IEntityRemover<TEntity>
        where TEntity : IEntity
    {
        /// <summary>
        /// Delete an entity from the data store.
        /// </summary>
        /// <param name="entity">The entity to delete</param>
        void Delete(TEntity entity);
        /// <summary>
        /// Deletes all entities that match the specified where expression.
        /// </summary>
        /// <param name="whereExpression">The where expression.</param>
        void Delete(Expression<Func<TEntity, bool>> whereExpression);
    }
    /// <summary>
    /// This interface defines all properties and methods common to all Repositories.
    /// </summary>
    public interface IRepository { }
    /// <summary>
    /// This interface defines all properties and methods common to all Read-Only repositories.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IReferenceRepository<TEntity> : IRepository, IEntityReader<TEntity>
       where TEntity : IEntity
    {
    }
    /// <summary>
    /// This interface defines all properties and methods common to all Read-Write Repositories.
    /// </summary>
    public interface IRepository<TEntity> : IReferenceRepository<TEntity>, IEntityCreator<TEntity>,
        IEntityUpdater<TEntity>, IEntityRemover<TEntity>
        where TEntity : IEntity
    {
    }
