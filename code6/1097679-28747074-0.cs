    public class SomeService : ISomeService
    {
        private readonly ILogReporting _logger;
        public SomeService(ILogReporting logger)
        {
            _logger = logger;
        }
        // .... code....
    }
