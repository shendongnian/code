    public class Logger<T>  where T : new()
    {
        private Func<T, string> _readFunc;
        private T _member;
    
        public Logger(Func<T, string> readFunc) 
        {
            _readFunc = readFunc; 
            _member  = new T();
        }
    
        public string Read()
        {
            return _readFunc(_member); 
        }
    }
