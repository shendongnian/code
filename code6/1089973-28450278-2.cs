    public class Logger<T>  where T : new()
    {
        private Func<T, string> _readFunc;
        private T _member;
    
        public Logger(Func<T, string> readFunc) 
        {
            _readFunc = readFunc; 
            _member  = new T();
        }
    
        // Use this if you already have an instance of your data type
        public Logger(Func<T, string> readFunc, T member)
        {
           _readFunc = readFunc;
           _member  = member;
        }
    
        public string Read()
        {
            return _readFunc(_member); 
        }
    }
