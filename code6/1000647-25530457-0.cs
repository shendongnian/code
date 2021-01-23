    public class Repository : IRepository, IDisposable
    {
        private IEntities context;
        public Repository(IEntities context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            this.context = context;
        }
        public IQueryable<T> GetAll<T>() 
            where T : class
        {
            return context.GetDbSet<T>();
        }
        #region IDisposable
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        public virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
                context = null;
            }
        }
        #endregion
    }
