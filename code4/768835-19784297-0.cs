    public abstract class BaseLookup<TEntity>
    {
        // Constructor
        protected BaseLookup()
        {
            this.SubsetIdentifier = null;
        }
        // Properties
        public virtual object SubsetIdentifier { get; set; }
        // Public Methods
        
        public abstract IEnumerable<TEntity> Read();
        public virtual TEntity ReadSingle()
        {
            return default(TEntity);
        }
        // Protected Methods
        /// <summary>
        /// Retrieve translated entities from the database. The methods used to do this
        /// are specified from the child class as parameters (i.e. Action or Func delegates).
        /// </summary>
        /// <param name="loadSubsetFunc">Specify how to load a set of database records.
        /// Return boolean confirmation that records were found.</param>
        /// <param name="orderByAction">Specify what should happen to sort the results.</param>
        /// <param name="translateRowFunc">Specify how a database record should translate to
        /// a model entity. Return the new entity.</param>
        /// <param name="moveNextFunc">Specify how the database row pointer should move on.
        /// Return FALSE on a call to the final row.</param>
        /// <returns>A set of translated entities from the database.</returns>
        /// <example><code>
        ///
        /// return base.ReloadRecords(
        ///     _dOOdad.LoadAll,
        ///     () =>
        ///     {
        ///         _dOOdad.Sort = _dOOdad.GetAutoKeyColumn();
        ///     },
        ///     () =>
        ///     {
        ///         var entity = new LookupEntity();
        ///         return entity.PopulateLookupEntity(_dOOdad.CurrentRow.ItemArray);
        ///     },
        ///     _dOOdad.MoveNext);
        ///     
        /// </code></example>
        protected virtual IEnumerable<TEntity> ReloadRecords(Func<bool> loadSubsetFunc,
            Action orderByAction, Func<TEntity> translateRowFunc, Func<bool> moveNextFunc)
        {
            // If records are found, sort them and return set of entities
            if (loadSubsetFunc())
            {
                orderByAction();
                do
                {
                    var entity = translateRowFunc();
                    yield return entity;
                }
                while (moveNextFunc());
            }
            else
            {
                Debug.WriteLine(
                    string.Format(
                        "# ZERO records found: Returning empty set of {0}.",
                        typeof(TEntity).Name));
            }
        }
    }
