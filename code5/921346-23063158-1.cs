    using System;
    
    public class EmployeeListNotFoundException: Exception
    {
        int _codeException; 
        public EmployeeListNotFoundException()
        {
        }
    
        public EmployeeListNotFoundException(string message,int codeException)
            : base(message)
        {
                      _codeException=codeException; 
        }
    
        public EmployeeListNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
       public int CodeException{get {return _codeException;} }
    }
