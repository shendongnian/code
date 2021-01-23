    public class ExceptionHandling
    {
        private Dictionary<string, string> exceptionlibrary = new Dictionary<string, string>       
            {
                //User
                {"10000", "Invalid user input."},
                {"10001", "Phone number is already registered."},
            };
        public Dictionary<string, string> ExceptionLibrary
        {
            get { return exceptionlibrary; }
        }
    }
