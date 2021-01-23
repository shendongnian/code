    class Date : IDataContract
    {
        public IDataContract Parse(string s)
        {
             return new Date();
        }
    }
    
    class Time : IDataContract
    {
        public IDataContract Parse(string s)
        {
             return new Time();
        }
    }
