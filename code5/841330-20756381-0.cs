    interface ILogger { }
    class Logger : ILogger { }
    interface IBarClass { }
    class BarClass : IBarClass
    {
        private readonly ILogger _logger;
        public BarClass(ILogger logger)
        {
            _logger = logger;
        }
        public void BarMethod()
        {
            //Do something
        }
    }
    class FooClass
    {
        private readonly ILogger _logger;
        private readonly IBarClass _barClass;
        public FooClass()
        {
            _logger = new Logger();
            _barClass = new BarClass(_logger);
        }
        public FooClass(ILogger logger, IBarClass barClass)
        {
            _logger = logger;
            _barClass = barClass;
        }
        public void FooMethod()
        {
            //Do something
        }
    }
