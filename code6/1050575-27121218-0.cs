    private void innerMethod()
    {
        try 
        {
            throw;
        }
        catch
        {
            throw;
        }
        someMethodThatWillNotBeExecuted();
    }
    public void outerMethod()
    {
        try 
        {
            innerMethod();
        }
        catch
        {
            thisWillBeExecuted();
        }
        thisWillAlsoBeExecuted();
    }
