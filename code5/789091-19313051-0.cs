    try
    {
        try
        {
            // Do you thing.
        }
        catch(Exception e)
        {
            throw new CustomException("I catched this: " + e.Message, e);
        }
    }
    catch(CustomException e)
    {
        // Do your exception handling here.
    }
