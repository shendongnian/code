    public class CustomException : Exception
    {
        public CustomException()
            : base()
        {
        }
    
        public CustomException(string message)
            : base(message) 
        { 
        }
    
        public CustomException(string message, Exception innerException)
            : base(message, innerException)
        { 
        }
    
    //...other constructors with parametrized messages for localization if needed
    }
---
    catch (Exception ex)
    {
        throw new CustomException("Something went wrong", ex);
    }
