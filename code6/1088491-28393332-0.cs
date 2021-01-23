    class PrefetchedRepository : IRepository
    {
        private readonly Task _prefetchingTask;
        private readonly ICollection<IEntry> _entries = new List<IEntry>();
        private readonly IRepository _underlyingRepository;
    
        public PrefetchedRepository(IRepository underlyingRepository)
        {
            _underlyingRepository = underlyingRepository;
            // Background initialization starts here
            _prefetchingTask = Task.Factory.StartNew(Prefetch);
        }
    
        public Task Initialization
        { 
            get
            {
                return _prefetchingTask;
            }
        }
        ...
    }
