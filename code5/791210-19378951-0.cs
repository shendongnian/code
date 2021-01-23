    public class CustomException : Exception
    {
        public CustomException(string message, int hresult)
            : base(message)
        {
            HResult = hresult
        }
    }
