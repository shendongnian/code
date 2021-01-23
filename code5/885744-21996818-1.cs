    public class ErrorCode
    {
        public static readonly ErrorCode COMMONS_DB_APP_LEVEL = new ErrorCode("Application problem: {0}", "Cause of the problem");
        public static readonly ErrorCode COMMONS_DB_LOW_LEVEL = new ErrorCode("Low level problem: {0}", "Cause of the problem");
        public static readonly ErrorCode COMMONS_DB_CONFIGURATION_PROBLEM = new ErrorCode("Configuration problem: {0}", "Cause of the problem");
    
        private String message;
        private String[] argumentDescriptions;
    
        private ErrorCode(String message, params String[] argumentDescriptions)
        {
            this.message = message;
            this.argumentDescriptions = argumentDescriptions;
        }
    
        public String[] GetArgumentDescriptions()
        {
            return argumentDescriptions;
        }
    
        public String GetKey()
        {
            // Need to implement this yourself
        }
    
        public String GetMessage()
        {
            return message;
        }
    }
    Console.WriteLine(ErrorCode.COMMONS_DB_APP_LEVEL.GetMessage(), "Foo"); 
    // Application problem: Foo
