    private void Wrapper()
    {
        try
        {
            Method();
        }
        catch
        {
            Method();
        }
    }
    
    private void Method()
    {
        try
        {
            // Operations
        }
        catch
        {
            throw;
        }
    }
