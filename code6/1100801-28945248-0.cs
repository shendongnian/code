    class LoggerViewModel : IViewModel
    {
        private readonly IViewModel _originalVM;
        private readonly static Logger _logger = new Logger(); 
    
        public LoggerViewModel(IViewModel originalVM) 
        {
            _originalVM = originalVM;
        }
    
        public string SimpleProperty 
        {
            get 
            {
                _logger.Log("Page requested SimplePriperty and value is " + _originalVM.SimpleProperty);
                return _originalVM.SimpleProperty;
            }
            set
            {
                _logger.Log("Page changed SimpleProperty and value is " + _originalVM.SimpleProperty);
                _originalVM.SimpleProperty = value;
            }
        }
    }
