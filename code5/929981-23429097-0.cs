    public class UnitOfWork : IDisposable
    {
        private static BlogSite.Domain.BlogSiteModelContainer context;
        public IBlogRepository blogRepository;
        public UnitOfWork()
        {
            context = new BlogSite.Domain.BlogSiteModelContainer();;
            blogRepository = new BlogRepository(context);
        }
        public void Save()
        {
            context.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
