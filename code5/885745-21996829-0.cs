    public class ErrorCode
        {
            public enum ErrorCode
            {
                [Description("Application level problem")]    
                COMMONS_DB_APP_LEVEL,
                [Description("Database level problem")]
                COMMONS_DB_LOW_LEVEL,
                [Description("Configuration level problem")]
                COMMONS_DB_CONFIGURATION_PROBLEM
            }
            private String message;
            private String[] argumentDescriptions;
    
            private ErrorCode(String message, String[] argumentDescriptions)
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
                return argumentDescriptions();
            }
    
            public String GetMessage()
            {
                return message;
            }
        }
