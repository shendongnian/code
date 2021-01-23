    public static void AssertContractFailure(Action action)
    {
        try
        {
            action();
            Assert.Fail("Expected contract violation");
        }
        catch (Exception e)
        {
            if (...) // I can't remember offhand what you'd need to check
            {
                throw;
            }
        }
    }
