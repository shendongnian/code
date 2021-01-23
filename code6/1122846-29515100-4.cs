    public class ArgumentNotOddException : ArgumentException
    {
        public ArgumentNotOddException(string paramName)
            : base(@"The argument must be odd", paramName)
        {
    
        }
    }
    
    public class MyClass
    {
        public void DoSomething(int x)
        {
            if (x%3 == 0) throw new ArgumentNotOddException("x");
        }
    }
