    public SomeReturnValue GetSomeData(someIdentifier)
    {
        var tries = 0;
        while (tries < someConfiguredMaximum)
        {
            try
            {
                tries++;
                return someDataAccessObject.GetSomeData(someIdentifier);
            }
            catch (SqlException e)
            {
                someLogger.LogError(e);
                // maybe wait for some number of milliseconds?  make the method async if possible
            }
        }
        throw new CustomException("Maximum number of tries has been reached.");
    }
