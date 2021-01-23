    public class ExceptionHandling
    {
        public ExceptionHandling()
        {
            exceptionlibrary = new Dictionary<string, string>()
            {
                //User
                {"10000", "Invalid user input."},
                {"10001", "Phone number is already registered."},
            }; 
        }
 
        private Dictionary<string, string> exceptionlibrary;
        public Dictionary<string, string> ExceptionLibrary
        {
            get { return exceptionlibrary; }
        }
