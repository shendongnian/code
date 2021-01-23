    public interface IFavoritesRepository : IDisposable
    {
        // code here
    }
    public class FavoritesRepository : IFavoritesRepository
    {
        private bool disposed = false;
    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                db.Dispose();
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
