    var exceptionThrown = true;
    try 
    {
        OnClick();
        exceptionThrown = false;
    }
    catch(System.SomeSpecificException ex)
    {
        Handle(ex);
        throw;
        // whoa, I added specific handler, but cleanup is called anyway!
    }
    finally
    {
        if (exceptionThrown) 
        {
            // Cleanup the buttonbase state 
            SetIsPressed(false); 
            ReleaseMouseCapture();
        } 
    }
