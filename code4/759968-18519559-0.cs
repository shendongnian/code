    public void MethodName(Exception error, ... ) 
    { 
        if (error is NullReferenceException)
        {
            //null ref specific code
        }
        else if (error is InvalidOperationException)
        {
            //invalid operation specific code
        }
        else
        {
            //other exception handling code
        }
    }
