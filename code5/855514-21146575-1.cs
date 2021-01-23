    public static addSomething(int id)
    {
        string msg = getStringMsg(id);
        try
        {
            //do lots of stuff
            Console.WriteLine(msg)
        }
        catch (Exception e)
        {
            string errorMessage = (id == 1) ? 
               "Exception msg 1: " : "Exception msg 2: ";
    
            throw new FooException(errorMessage + msg, e);
        }
    }
