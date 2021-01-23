    protected string DisplayRespiteDate(object stepRespiteDay)
    {
        DateTime theDate;
        // Attempt to cast object to DateTime
        try
        {
            theDate = (DateTime)stepRespiteDay;
        }
        catch (Exception)
        {
            // Do something with failed conversion here, throw for example
            throw;
        }
        return theDate.ToString("dddd dd MMMM yyyy");
    }
