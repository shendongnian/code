    public static class xAssert
    {
        public static TException Throws<TException>(Action a) where TException : Exception
        {
            try
            {
                a();
            }
            catch (Exception ex)
            {
                var throws = ex as TException;
                if (throws != null)
                    return throws;
            }
            Assert.Fail();
            return default(TException);
        }
    }
