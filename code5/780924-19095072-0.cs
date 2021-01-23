    try
    {
        var p = new MyObject(prms); // this code failed and throw exception-"Unknown exception" 
    
        return p;
    }
    catch (Exception ex)
    {
        If (ex.Message.Contains("Unknown exception"))
           {
             //Add code here to handle the Unknown exception
           }
        else
           {
             Console.WriteLine("Error! "+ex.Message);
           }
    }
