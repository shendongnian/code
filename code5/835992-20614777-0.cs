    private static bool FilePathHasInvalidChars(string userInputPath)
    {
        if(string.IsNullOrWhiteSpace(userInputPath) throw new
            ArgumentNullException("userInputPath");
        try
        {
            Path.GetFullPath(userInputPath);//this is where the warning appears
    
        }
        catch (ArgumentException e)
        {
            Log.Error(String.Format(
                "The Program failed to run due to invalid characters or empty string value for the Input Directory. Full Path : <{0}>. Error Message : {1}.",
                userInputPath, e.Message), e);
            throw;    
        }
        catch (Exception e)
        {
            Log.Error(String.Format(
                "The Program failed to run due to invalid characters or empty string value for the Input Directory. Full Path : <{0}>. Error Message : {1}.",
                userInputPath, e.Message), e);
            return true;
    
        }
        return false;
    }
