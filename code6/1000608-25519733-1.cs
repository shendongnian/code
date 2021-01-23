    try
    {
        if(count<3)
        {
           //Processing
           return someValue;
        }
        else
        {
            return;
        }
    }
    catch(Exception ex)
    {
        return YourProcessingFunction(yourArgs, int count);
    }
