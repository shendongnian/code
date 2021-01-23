    try 
    {
        OnClick();
    }
    catch(System.SomeSpecificException ex)
    {
        Handle(ex);
        throw;
        // now, we're missing the cleanup
    }
    catch
    {
        SetIsPressed(false);
        ReleaseMouseCapture();
        throw;
    }
