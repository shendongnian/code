    /// <summary>
    /// This interface provides an abstraction for accessing a data source.
    /// </summary>
    public interface IDataContext : IDisposable
    {
        IQueryable<T> Query<T>() where T : class;
        T Add<T>(T item) where T : class;
        int Update<T>(T item) where T : class;
      
		void Delete<T>(T item) where T : class;
		
        /// <summary>
        /// Allow repositories to control when SaveChanges() is called
        /// </summary>
        int SaveChanges();
    }
