    public class DataContextBase
    {
    
        /// <summary>
        /// Gets or sets the forced MergeOption. When this is set all queries 
        /// generated using GetObjectSet will use this value
        /// </summary>
        public MergeOption? MergeOption { get; set; }
    
    
       /// <summary>
       /// Gets an ObjectSet of type T optionally providing a MergeOption.
       /// <remarks>Warning: if a DataContext.MergeOption is specified it will take precedence over the passed value</remarks>
       /// </summary>
       /// <typeparam name="TEntity">ObjectSet entity Type</typeparam>
       /// <param name="mergeOption">The MergeOption for the query (overriden by DataContext.MergeOption)</param>
       protected IQueryable<TEntity> GetObjectSet<TEntity>(MergeOption? mergeOption = null) where TEntity : class
       {
          var set = Context.CreateObjectSet<TEntity>();
          set.MergeOption = MergeOption ?? mergeOption ?? MergeOption.AppendOnly;
    
          return set;
       }
