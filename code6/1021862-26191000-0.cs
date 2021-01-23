    public interface ISomeInterface
    {
        bool DoSomething();
        
        int SomeValue { get; }
    }
    public class Example1 : ISomeInterface
    {
        public bool DoSomething()
        {
            return true;
        }
        
        public int SomeValue {
            get {
                return 42;
            }
        }
    }
    public class Example2 : ISomeInterface
    {
        public bool DoSomething()
        {
            return DateTime.IsLeapYear(DateTime.Now.Year);
        }
        
        public int SomeValue {
            get {
                return DateTime.Now.Year;
            }
        }
    }
