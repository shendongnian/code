    public interface INotifications : IDisposable 
    {
        (...)
    }
    internal class Notifications : INotifications
    {
        private readonly IDbContext _context;
        public Notifications(IDbContext context)
        {
            _context = context;
        }
        (...)
        public void Dispose()
        {
            _context.Dispose();
        }
    }
