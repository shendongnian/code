    try
    {
        FunctionThatThrowsArgumentNullException(myParameter);
    } catch (ArgumentNullException ane)
    {
        Log.WriteLine("Argument Null Exception Raised", ane);
        Log.WriteLine("Parameters supplied : {0}", myParameter);
        throw; // Pass the exception on, as we are only logging
    }
