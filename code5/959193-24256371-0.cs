    public class Bar
    {
        private readonly ILogger _logger;
        
        public Bar(ILogger logger)
        {
            _logger = logger;
        }
        
        public void Foo()
        {
            _logger.LogInformation();
        }
    }
