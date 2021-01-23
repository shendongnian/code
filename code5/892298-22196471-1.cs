    const string NO_VALUE = "Just a const to identify a missing param";
    [TestCase(null, Result = "optional")] // Either this... 
    [TestCase(NO_VALUE, Result = "optional")] // or something like this
    [TestCase("set", Result = "set")]
    public void MyTest(string optional)
    {
        // if(optional == null)  // if you use null
        if(optional == NO_VALUE) // if you prever the constant
        {
            // Do something
        }
        else{
            // Do something else
        }        
    }
