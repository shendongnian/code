    public sealed class ExpectedExceptionMessageAttribute<T> : ExpectedExceptionBaseAttribute
    {
    	readonly string _expectedMessage;
    	public ExpectedExceptionMessageAttribute(string expectedMessage)
    	{
    		_expectedMessage = expectedMessage;
    	}
    	
    	protected override void Verify(System.Exception exception)
    	{
    		// Handle assertion exceptions from assertion failures in the test method
    		base.RethrowIfAssertException(exception);
    
    		Assert.IsInstanceOfType(exception, typeof(T), "wrong exception type");
    		Assert.AreEqual(_expectedMessage, exception.Message, "wrong exception message");
    	}
    }
