    public class MyComponent
    {
        private bool _isInitialized; // I think this is a better name than _runOnce
        private bool _enable;
        
        public bool Enable
        {
            get
            {
                return _enable;
            }
            set
            {
                if (_enable == value)
                {
                    return;
                }
                
                if (value == true && !_isInitialized)
                {
                    Init();
                }
                
                _enable = value;
            }
        }
        
        private void Init()
        {
            // initialization logic here ...
        
            _isInitialized = true;
        }
    }
