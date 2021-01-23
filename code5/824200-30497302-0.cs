    protected override void Verify(Exception exception)
    {
        try
        {
             Assert.IsInstanceOfType<SpecialException>(exception);
        }
        catch (AssertionFailedException ex)
        {
             RethrowIfAssertException(ex);
        }
    }
