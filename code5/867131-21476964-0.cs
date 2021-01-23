    private void TopLevelMethod()
    {
        try
        {
            SomeMethod();
        }
        catch (Exception ex)
        {
            // Log/report exception/display to user etc.
        }
    }
    private void SomeMethod()
    {
        TestPartA();
        TestPartB();
        TestPartC();
        TestPartD();
    }
    private void TestPartA()
    {
        // Do some testing...
        try
        {
            if (somethingBadHappens)
            {
                throw new Exception("The error that happens");
            }
        }
        catch (Exception)
        {
            // Cleanup here. If no cleanup is possible, 
            // do not catch the exception here, i.e., 
            // try...catch would not be necessary in this method.
            // Re-throw the original exception.
            throw;
        }
    }
    private void TestPartB()
    {
        // No need for try...catch because we can't do any cleanup for this method.
        if (somethingBadHappens)
        {
            throw new Exception("The error that happens");
        }
    }
