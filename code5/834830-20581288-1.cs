    interface IDataContract<T>
    {
        T Parse(string s);
    }
    
    class Date : IDataContract<Date>
    {
        public Date Parse(string s)
        {
             return new Date();
        }
    }
    
    class Time : IDataContract<Time>
    {
        public Time Parse(string s)
        {
             return new Time();
        }
    }
