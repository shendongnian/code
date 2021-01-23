    protected override void Verify(Exception exception)
    {
        if (exception is UnitTestAssertException)
        {
            RethrowIfAssertException(exception);
        }
        try
        {
             Assert.IsInstanceOfType<SpecialException>(exception);
        }
        catch (AssertionFailedException ex)
        {
             RethrowIfAssertException(ex);
        }
    }
