    class LazyPcSubsContextProvider : IPcSubsContextProvider
    {
        private readonly Lazy<PCSubsDBContext> context;
        public LazyPcSubsContextProvider(Func<PCSubsDBContext> factory) {
            this.context = new Lazy<PCSubsDBContext>(factory);
        }
        public PCSubsDBContext Context { get { return this.context.Value; } }
    }
