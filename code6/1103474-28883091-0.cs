    public override String ToString() {
            String message = Message;
            String s;
            if (_className==null) { 
                _className = GetClassName();
            } 
 
            if (message == null || message.Length <= 0) {
                s = _className; 
            }
            else {
                s = _className + ": " + message;
            } 
            if (_innerException!=null) { 
                s = s + " ---> " + _innerException.ToString() + Environment.NewLine + "   " + Environment.GetResourceString("Exception_EndOfInnerExceptionStack"); 
            }
            if (StackTrace != null)
                s += Environment.NewLine + StackTrace;
 
            return s;
        }
