    try
    {
        Con.Open();
    }
    catch(Exception ex)
    {
        //do something with exception.
    }
    finally
    {
        Con.Close();
    } 
