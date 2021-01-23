    try
    {
        //some code which is not for database related 
        try
        {
          //database related code with connection open
        }
        catch(//database related exception)
        {
            //statement to terminate
        }
        **finally()
        {
            //close connection,destroy object
        }**
    }
    catch(//general exception)
    {
        //statement to terminate
    }
