    public class Repository : IDisposable
    {
        private readonly bool _autodispose = false;
        private readonly Lazy<Context> _context = new Lazy<Context>(CreateContext);
        public Repository(bool autodispose = false) {
            _autodispose = autodispose;
        }
        public Task<File> GetFile(int id) {
            // public query methods are still one-liners
            return WithContext(c => c.Files.FirstOrDefaultAsync(f => f.Id == id));
        }
        private async Task<T> WithContext<T>(Func<Context, Task<T>> func) {
            if (_autodispose) {
                using (var c = CreateContext()) {
                    return await func(c);
                }
            }
            else {
                return await func(_context.Value);
            }
        }
        private static Context CreateContext() {
            var c = new Context();
            c.Configuration.LazyLoadingEnabled = false;
            return c;
        }
        public void Dispose() {
            if (_context.IsValueCreated)
                _context.Value.Dispose();
        }
    }
