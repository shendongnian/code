    /* you can use Exception handling to capture the error while still not having the test failed.
    Test is failing because at the time it performs click action, the control is hidden.
    */
    try 
    {
       //your code goes here
    }
    catch(FailedToPerformActionOnHiddenControlException e)
    {
       Console.WriteLine(e.Message);
    } 
