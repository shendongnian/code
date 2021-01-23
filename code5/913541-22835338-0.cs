    try
    {
         // do stuff
    }
    catch (OracleException ex)
    {
        if (ex.Code == 15) throw new MyApplicationException("Something your users might make sense of", ex); // Code==15 is made-up
    }
    // Catch more specific errors where you know what happened and can give meaningful information to the user
    catch (Exception ex)
    {
        throw new MyApplicationException("General error message: Something went horribly wrong", ex);
    }
