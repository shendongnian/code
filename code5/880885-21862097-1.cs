    public class TheAuthorOfThisMethodScrewedUpException: Exception
    {
        public EmployeeListNotFoundException()
        {
        }
        public EmployeeListNotFoundException(string message)
            : base(message)
        {
        }
        public EmployeeListNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
