    public class ContextService : IDisposable
    {
        private Context _context;
        public void Dispose()
        {
            _context.Dispose();
        }
        public ContextService(Context context)
        {
            _context = context;
        }
    //... do stuff with the context
