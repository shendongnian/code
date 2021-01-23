    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                NotImplementedMethod();
            }
            catch (NotImplementedException)
            {
                Console.WriteLine("Exception caught");
            }
            Console.Read();
        }
        public static void NotImplementedMethod()
        {
            throw DebugException.Wrap(new NotImplementedException());//Breaks here when debugger is attached
        }
    }
    public class DebugException : Exception
    {
        public static Exception Wrap(Exception innerException)
        {
            if(Debugger.IsAttached)
            {
                return new DebugException(innerException);
            }
            else
            {
                return innerException;
            }
        }
        public DebugException(Exception innerException)
            : base("Debug exception", innerException)
        {
        }
    }
