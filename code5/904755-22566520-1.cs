    public TException Throws<TException>(Action act) where TException : Exception 
    {
            // act
            try { act(); } catch (TException ex) { return ex; }
    
            // assert
            Assert.Fail("Expected exception");
            return default(TException);   //never reached
    }
