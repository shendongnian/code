    public class MyException : Exception
    {
        public MyException(string message, Exception ex) : base(ex.Message, ex)
        {
        }
    }
