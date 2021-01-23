    class Base
    {
        public Base(string parameter)
        {
            try
            {
                // do something with parameter
            }
            catch (Exception exception)
            {
                ExceptionProperty = exception;
            }
        }
        public Exception ExceptionProperty  { get; }
    }
    class Derived : Base("parameter")
    {
        if (ExceptionProperty != null)
        {
            // handle the exception
        }
    }
