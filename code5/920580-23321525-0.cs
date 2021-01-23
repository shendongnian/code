    public static void AssertDoesNotThrow<T>(NUnit.Framework.TestDelegate testDelegate) where T : Exception
    {
        try
        {
            testDelegate.Invoke();
        }
        catch (T exception)
        {
            Assert.Fail("Expected: not an <{0}> exception or derived type.\nBut was: <{1}>",
                        typeof (T).FullName, 
                        exception.GetType().FullName);
        }
    }
