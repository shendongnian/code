        private readonly SynchronizationContext _context = SynchronizationContext.Current;
        private void StartWorker()
        {
            Worker w = new Worker((s) => _context.Post(delegate { StatusText = s; }, null));
        }
