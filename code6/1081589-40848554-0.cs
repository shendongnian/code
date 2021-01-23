    public class ExpectedInnerExceptionAttribute : ExpectedExceptionBaseAttribute
     {
       public ExpectedInnerExceptionAttribute(Type exceptionType)
       {
         this.ExceptionType = exceptionType;
       }
    
       public Type ExceptionType { get; private set; }
    
       protected override void Verify(Exception ex)
       {
         if (ex != null && ex.InnerException != null
               && ex.InnerException.GetType() == this.ExceptionType)
          {
             return;
          }
    
           throw ex;
        }
    }
