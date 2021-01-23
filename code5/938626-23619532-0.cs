    /// <summary>
    /// This class aids in loading a lot of related data in Entity Framework.
    /// <para>
    /// Typically Entity Framework either lets you load entities Eagerly or Lazily,
    /// but neither case handles things very well once you are adding many chained
    /// relationships. A more ideal approach in these cases is to load all of the
    /// entities you are going to need for a given relationship in a single round-trip, 
    /// and do this once for every relationship you're interested in.
    /// That's what this class helps with.
    /// </para>
    /// <para>
    /// To use: simply create an EntityRelationshipLoader with the initial 
    /// Entity-Framework-backed queryable that will be the basis of all the data
    /// you're going to be loading. Then for each entity you want to load in relationship
    /// to that original data type, call either <see cref="Include{TProp}"/> or
    /// <see cref="IncludeMany{TProp}"/>. The return value from calling these methods may
    /// be retained and used to include other property relationships based on the
    /// property that you just defined. Each call to any of these methods will produce a
    /// single round-trip.
    /// </para>
    /// <remarks>
    /// Remember that all actions on the loader, including its original
    /// construction, must be performed while the query's Entity Framework context
    /// is active.
    /// </remarks>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EntityRelationshipLoader<T> : IRelationshipPropertyBuilder<T>
    {
        private readonly IQueryable<T> _src;
        public EntityRelationshipLoader(IQueryable<T> src) : this(src, true)
        {
        }
        private EntityRelationshipLoader(IQueryable<T> src, bool evaluateSource)
        {
            _src = src;
            if (evaluateSource)
            {
                LoadEntities(src);
            }
        }
        public IRelationshipPropertyBuilder<TProp> IncludeMany<TProp>(Expression<Func<T, IEnumerable<TProp>>> navProp)
        {
            LoadEntities(_src.Select(navProp));
            return new EntityRelationshipLoader<TProp>(_src.SelectMany(navProp), false);
        }
        public IRelationshipPropertyBuilder<TProp> Include<TProp>(Expression<Func<T, TProp>> navProp)
        {
            return new EntityRelationshipLoader<TProp>(_src.Select(navProp), true);
        }
        /// <summary>
        /// Simple helper method to cause the given query to be executed, 
        /// thereby loading all the entities the query represents.
        /// </summary>
        /// <param name="query"></param>
        private void LoadEntities<T1>(IQueryable<T1> query)
        {
    #pragma warning disable 168
            foreach (var item in query)
            {
            }
    #pragma warning restore 168
        }
