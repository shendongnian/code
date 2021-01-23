    try
    {
        // code here
        ...
    }
    catch (Exception ex)
    {
        if (ex is NullReferenceException || ex is ArgumentNullException 
                || ex is FormatException || ex is OverflowException)
        {
            // handle ex
            ...
            return;
        }
        throw;
    }
